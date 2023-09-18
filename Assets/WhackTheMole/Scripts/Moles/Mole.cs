using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.Grid;
using WhackTheMole.Scripts.Utilities;

namespace WhackTheMole.Scripts.Moles
{
    public class Mole
    {
        private readonly MoleData _moleData;
        private readonly MoleView _moleView;
        private readonly Timer _timer;
        private readonly PlayerData _playerData;
        private readonly ICell _cell;

        public Mole(MoleConfig moleConfig, ICell cell, PlayerData playerData)
        {
            _moleData = moleConfig.GetMoleData();
            _cell = cell;
            _playerData = playerData;
            _moleView = InstantiateView();

            _timer = new Timer(_moleData.Lifetime);
            _timer.StartTimer();
            
            _moleView.OnClickEvent += _moleData.TakeDamage;
            _moleView.OnUpdateEvent += _timer.Tick;
            _timer.OnTimesUpEvent += DamagePlayer;
            _moleData.OnDieEvent += AddScore;

            _timer.OnTimesUpEvent += OnDisposable;
            _moleData.OnDieEvent += OnDisposable;
        }

        private void OnDisposable()
        {
            _cell.AddMole(null);
            
            _moleView.OnClickEvent -= _moleData.TakeDamage;
            _moleView.Destroy();
            _moleView.OnUpdateEvent -= _timer.Tick;
            _timer.OnTimesUpEvent -= DamagePlayer;
            _moleData.OnDieEvent -= AddScore;

            _timer.OnTimesUpEvent -= OnDisposable;
            _moleData.OnDieEvent -= OnDisposable;
        }
        
        private MoleView InstantiateView()
        {
            var cellTransform = _cell.Transform;
            return Object.Instantiate(_moleData.ViewPrefab, cellTransform.position, Quaternion.identity,
                    cellTransform);
        }

        private void AddScore()
        {
            _playerData.AddScore(_moleData.Reward);
        }
        
        private void DamagePlayer()
        {
            _playerData.TakeDamage(_moleData.Damage);
        }
    }
}