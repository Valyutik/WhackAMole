using System.Collections.Generic;
using UnityEngine;

namespace WhackTheMole.Scripts.GameMachines
{
    public sealed class GameMachine
    {
        public GameState GameState { get; private set; } = GameState.Off;

        private readonly List<IGameStateListener> _listeners = new();

        public GameMachine(IEnumerable<IGameStateListener> gameStateListeners)
        {
            foreach (var gameStateListener in gameStateListeners)
            {
                _listeners.Add(gameStateListener);
            }
        }
        
        public void StartGame()
        {
            if (GameState != GameState.Off)
            {
                Debug.LogWarning($"You can start game only from {GameState.Off} state!");
                return;
            }

            GameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                listener.OnStartGame();
            }
        }
        
        public void PauseGame()
        {
            if (GameState != GameState.Play)
            {
                Debug.LogWarning($"You can pause game only from {GameState.Play} state!");
                return;
            }

            GameState = GameState.Pause;
            
            foreach (var listener in _listeners)
            {
                listener.OnPauseGame();
            }
        }

        public void ResumeGame()
        {
            if (GameState != GameState.Pause)
            {
                Debug.LogWarning($"You can resume game only from {GameState.Pause} state!");
                return;
            }

            GameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                listener.OnResumeGame();
            }
        }

        public void FinishGame()
        {
            if (GameState != GameState.Play)
            {
                Debug.LogWarning($"You can finish game only from {GameState.Play} state!");
                return;
            }

            GameState = GameState.Finish;
            
            foreach (var listener in _listeners)
            {
                listener.OnFinishGame();
            }
        }

        public void AddListener(IGameStateListener gameStateListener)
        {
            _listeners.Add(gameStateListener);
        }

        public void RemoveListener(IGameStateListener gameStateListener)
        {
            _listeners.Remove(gameStateListener);
        }
    }
}