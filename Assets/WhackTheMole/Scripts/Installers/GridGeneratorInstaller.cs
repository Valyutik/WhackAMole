using WhackTheMole.Scripts.Grid;
using UnityEngine;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class GridGeneratorInstaller : MonoInstaller
    {
        [SerializeField] private Transform container;
        [Range(2,10)]
        [SerializeField] private int cellCount;
        private Cell _cellPrefab;

        public override void InstallBindings()
        {
            _cellPrefab = Resources.Load<Cell>("Prefabs/Cells/Cell");
            var gridGenerator = new SquareGridGenerator(_cellPrefab, container, cellCount);
            Container.Bind<GridGeneratorBase>().To<SquareGridGenerator>().FromInstance(gridGenerator).AsSingle();
            Container.Bind<IGameStateListener>().To<SquareGridGenerator>().FromInstance(gridGenerator);
        }
    }
}
