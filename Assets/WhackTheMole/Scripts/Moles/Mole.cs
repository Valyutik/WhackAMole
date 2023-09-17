using UnityEngine;
using WhackTheMole.Scripts.Grid;

namespace WhackTheMole.Scripts.Moles
{
    public class Mole
    {
        private readonly MoleConfig _moleConfig;
        private readonly ICell _transformCell;

        public Mole(MoleConfig moleConfig, ICell transformCell)
        {
            _moleConfig = moleConfig;
            _transformCell = transformCell;
            InstantiateView();
        }

        private void InstantiateView()
        {
            var cellTransform = _transformCell.Transform;
            var moleView =
                Object.Instantiate(_moleConfig.ViewPrefab, cellTransform.position, Quaternion.identity,
                    cellTransform);
        }
    }
}