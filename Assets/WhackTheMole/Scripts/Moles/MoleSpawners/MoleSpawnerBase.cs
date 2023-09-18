using System.Collections.Generic;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.Grid;
using Zenject;

namespace WhackTheMole.Scripts.Moles.MoleSpawners
{
    public abstract class MoleSpawnerBase : ITickable, IGameStateListener
    {
        protected readonly MoleConfig[] MoleConfigs;
        protected readonly IEnumerable<ICell> Cells;
        protected readonly PlayerData PlayerData;
        protected readonly float SpawnDelay;
        protected bool CanSpawn;

        protected MoleSpawnerBase(GridGeneratorBase gridGenerator, MoleSpawnerData data)
        {
            PlayerData = data.PlayerData;
            Cells = gridGenerator.Cells;
            MoleConfigs = data.MoleConfigs;
            SpawnDelay = data.SpawnDelay;
        }

        public void OnStartGame()
        {
            CanSpawn = true;
        }

        public void OnFinishGame()
        {
            CanSpawn = false;
        }

        public void Tick()
        {
            SpawnMole();
        }

        protected abstract void SpawnMole();
    }
}