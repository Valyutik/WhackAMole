using WhackTheMole.Scripts.Grid;
using UnityEngine;
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
            Container.Bind<GridGeneratorBase>().To<SquareGridGenerator>().FromNew().AsSingle()
                .WithArguments(_cellPrefab, container, cellCount);
        }
    }
}
