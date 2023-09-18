using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.Utilities;
using UnityEngine;
using Zenject;
using System;

namespace WhackTheMole.Scripts.GameConditions
{
    public class PlayerData : ITickable, IGameStateListener
    {
        public event Action OnHpPlayerLostEvent;
        public event Action<string> OnChangePlayTimeEvent; 
        public event Action<string> OnChangeHealthEvent; 
        public event Action<string> OnScoreChangeEvent;
        public event Action OnWinEvent;

        private int Score { get; set; }
        private readonly int _numberWim;
        
        public float PlayTime { get; }
        public int Health { get; private set; }
        public Timer Timer { get; }

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

        public void Tick()
        {
            Timer?.Tick(Time.deltaTime);
            OnChangePlayTimeEvent?.Invoke(Timer!.Time.ToString("0.0"));
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            OnChangeHealthEvent?.Invoke(Health.ToString());
            if (Health <= 0)
            {
                OnHpPlayerLostEvent?.Invoke();
            }
        }
        
        public void AddScore(int count)
        {
            Score += count;
            OnScoreChangeEvent?.Invoke(Score.ToString());
            if (Score < _numberWim) return;
            OnWinEvent?.Invoke();
        }
    }
}