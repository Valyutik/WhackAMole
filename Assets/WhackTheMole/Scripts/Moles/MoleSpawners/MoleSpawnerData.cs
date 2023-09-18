using WhackTheMole.Scripts.GameConditions;

namespace WhackTheMole.Scripts.Moles.MoleSpawners
{
    public class MoleSpawnerData
    {
        public MoleConfig[] MoleConfigs { get; private set; }
        public PlayerData PlayerData { get; private set; }
        public float SpawnDelay { get; private set; }

        public MoleSpawnerData(MoleConfig[] moleConfigs, PlayerData playerData,
            float spawnDelay)
        {
            MoleConfigs = moleConfigs;
            PlayerData = playerData;
            SpawnDelay = spawnDelay;
        }
    }
}