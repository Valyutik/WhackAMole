using System;

namespace WhackTheMole.Scripts.Utilities
{
    public class Timer
    {
        public event Action OnTimesUpEvent;
        
        public float Time { get; private set; }
        private bool _isRun;

        public Timer(float time)
        {
            Time = time;
        }

        public void Tick(float deltaTime)
        {
            if (!_isRun) return;
            
            Time -= deltaTime;
            if (!(Time <= 0)) return;
            _isRun = false;
            OnTimesUpEvent?.Invoke();
        }

        public void StartTimer()
        {
            _isRun = true;
        }
        
        public void StopTimer()
        {
            _isRun = false;
        }
    }
}