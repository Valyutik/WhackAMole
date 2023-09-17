using WhackTheMole.Scripts.Grid;
using UnityEngine;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class GridGeneratorInstaller : MonoInstaller
    {
        [SerializeField] private Transform transformParent;
        [Range(2,10)]
        [SerializeField] private int cellCount;
        
        private Cell _cellPrefab;

        public override void InstallBindings()
        {
            _cellPrefab = Resources.Load<Cell>("Prefabs/Cells/Cell");
            var gridGenerator = new SquareGridGenerator(_cellPrefab, transformParent, cellCount);
            Container.Bind<GridGeneratorBase>().FromInstance(gridGenerator).AsSingle();
        }
    }
}
