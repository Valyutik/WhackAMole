using WhackTheMole.Scripts.Grid;
using System.Threading.Tasks;
using System.Linq;
using System;
using Random = UnityEngine.Random;

namespace WhackTheMole.Scripts.Moles
{
    public class MoleRandomSpawner : MoleSpawnerBase
    {
        public MoleRandomSpawner(GridGeneratorBase gridGenerator, MoleConfig[] moleConfigs, float spawnDelay) : base(
            gridGenerator, moleConfigs, spawnDelay)
        {
        }
        
        protected override async void SpawnMole()
        {
            if (!CanSpawn) return;
            CanSpawn = false;
            var randomIndex = Random.Range(0, Cells.Count());
            var currentCell = Cells.ElementAt(randomIndex);

            if (currentCell.CheckMole())
            {
                var mole = new Mole(MoleConfigs[Random.Range(0, MoleConfigs.Length)], currentCell);
                currentCell.AddMole(mole);
            
                await Task.Delay(Convert.ToInt32(SpawnDelay * 1000));
                CanSpawn = true;
            }
            else
            {
                CanSpawn = true;
            }
        }
    }
}