using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.Camera;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class VirtualCameraAndGameMachineInstaller : MonoInstaller
    {
        [Range(0,100)]
        [SerializeField] private float padding;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        public override void InstallBindings()
        {
            Container.Bind<CinemachineVirtualCamera>().FromInstance(virtualCamera).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraResizer>().FromNew().AsSingle()
                .WithArguments(padding).NonLazy();
            Container.Bind<GameMachine>().FromNew().AsSingle();
        }
    }
}