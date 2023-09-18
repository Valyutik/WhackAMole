using WhackTheMole.Scripts.UI;
using UnityEngine;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Transform container;
        
        public override void InstallBindings()
        {
        }

        private void Awake()
        {
            var prefabs = Resources.LoadAll<PlayerDataViewBase>("Prefabs/Views");

            foreach (var playerDataViewBase in prefabs)
            {
                var viewBase =
                    Container.InstantiatePrefabForComponent<PlayerDataViewBase>(playerDataViewBase, container);
            }
        }
    }
}