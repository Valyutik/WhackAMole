using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.Utilities;
using UnityEngine;
using Zenject;
using System;

namespace WhackTheMole.Scripts.GameConditions
{
    public class PlayerData : ITickable, IGameStateListener
    {
        public event Action OnHpPlayerLostEvent, OnWinEvent;
        public event Action<string> OnChangePlayTimeEvent, OnScoreChangeEvent, OnChangeHealthEvent;
        
        public Timer Timer { get; }
        public float PlayTime { get; }
        public int Health { get; private set; }
        private int Score { get; set; }
        
        private readonly int _numberWim;
        private bool _canChange = true;

        public PlayerData(int health, float playTime, int numberWim)
        {
            Health = health;
            PlayTime = playTime;
            _numberWim = numberWim;
            Timer = new Timer(PlayTime);
        }
        
        public void OnStartGame()
        {
            Timer.StartTimer();
        }

        public void OnFinishGame()
        {
            Timer.StopTimer();
            _canChange = false;
        }

        public void Tick()
        {
            Timer?.Tick(Time.deltaTime);
            OnChangePlayTimeEvent?.Invoke(Timer!.Time.ToString("0.0"));
        }

        public void TakeDamage(int damage)
        {
            if (!_canChange) return;
            Health -= damage;
            OnChangeHealthEvent?.Invoke(Health.ToString());
            if (Health <= 0)
            {
                OnHpPlayerLostEvent?.Invoke();
            }
        }
        
        public void AddScore(int count)
        {
            if (!_canChange) return;
            Score += count;
            OnScoreChangeEvent?.Invoke(Score.ToString());
            if (Score < _numberWim) return;
            OnWinEvent?.Invoke();
        }
    }
}