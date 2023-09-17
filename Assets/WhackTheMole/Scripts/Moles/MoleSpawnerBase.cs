using System.Collections.Generic;
using WhackTheMole.Scripts.Grid;
using Zenject;

namespace WhackTheMole.Scripts.Moles
{
    public abstract class MoleSpawnerBase : ITickable
    {
        protected readonly MoleConfig[] MoleConfigs;
        protected readonly float SpawnDelay;
        protected readonly IEnumerable<ICell> Cells;
        protected bool CanSpawn = true;

        protected MoleSpawnerBase(GridGeneratorBase gridGenerator, MoleConfig[] moleConfigs, float spawnDelay)
        {
            Cells = gridGenerator.Cells;
            MoleConfigs = moleConfigs;
            SpawnDelay = spawnDelay;
        }
        
        public void Tick()
        {
            SpawnMole();
        }

        protected abstract void SpawnMole();
    }
}