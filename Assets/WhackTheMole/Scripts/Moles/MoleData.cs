using System;

namespace WhackTheMole.Scripts.Moles
{
    public class MoleData
    {
        public event Action OnDieEvent;
        
        public MoleView ViewPrefab { get; private set; }
        public int Health { get; private set; }
        public float Lifetime { get; private set; }
        public int Reward { get; private set; }
        public bool IsAlive { get; private set; } = true;
        public int Damage { get; private set; }

        public MoleData(MoleView viewPrefab, int health, float lifetime, int reward, int damage)
        {
            ViewPrefab = viewPrefab;
            Health = health;
            Lifetime = lifetime;
            Reward = reward;
            Damage = damage;
        }

        public void TakeDamage()
        {
            if (!IsAlive) return;
            Health -= 1;
            if (Health > 0) return;
            IsAlive = false;
            OnDieEvent?.Invoke();
        }
    }
}