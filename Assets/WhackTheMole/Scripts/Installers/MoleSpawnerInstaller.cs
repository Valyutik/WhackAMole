using WhackTheMole.Scripts.Moles;
using UnityEngine;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class MoleSpawnerInstaller : MonoInstaller
    {
        [Range(0,10)]
        [SerializeField] private float spawnDelay;
        private MoleConfig[] _moleConfigs;
        
        public override void InstallBindings()
        {
            _moleConfigs = Resources.LoadAll<MoleConfig>("Configs");
            Container.BindInterfacesTo<MoleRandomSpawner>().FromNew().AsSingle()
                .WithArguments(_moleConfigs, spawnDelay);
        }
    }
}