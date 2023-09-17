using WhackTheMole.Scripts.Camera;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class VirtualCameraInstaller : MonoInstaller
    {
        [Range(0,100)]
        [SerializeField] private float padding;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        public override void InstallBindings()
        {
            Container.Bind<CinemachineVirtualCamera>().FromInstance(virtualCamera).AsSingle();
            Container.Bind<CameraResizer>().FromNew().AsSingle().WithArguments(padding).NonLazy();
        }
    }
}