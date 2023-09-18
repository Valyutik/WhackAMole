using WhackTheMole.Scripts.UI;
using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class GameConditionInstaller : MonoInstaller
    {
        [SerializeField] private SelectionPanelView panelView;
        [SerializeField] private LosePanelView losePanelView;
        [Range(1, 1000)]
        [SerializeField] private int scoreWin;
        [Range(1,10)]
        [SerializeField] private int heathPlayer;
        [Range(1,100)]
        [SerializeField] private float playTime;

        private PlayerData _data;
        
        public override void InstallBindings()
        {
            _data = new PlayerData(heathPlayer, playTime, scoreWin);
            Container.BindInterfacesAndSelfTo<PlayerData>().FromInstance(_data).AsSingle();
            
        }

        private void Awake()
        {
            BindCondition();
        }

        private void BindCondition()
        {
            var prefabs = Container.ResolveAll<PlayerDataViewBase>();
            panelView.OnHpConditionEvent += () =>
            {
                var hpLoseCondition = new HpLoseCondition(losePanelView, _data, Container.Resolve<GameMachine>());
                hpLoseCondition.Subscribe();
            };
            panelView.OnTimeConditionEvent += () =>
            {
                var timeLoseCondition = new TimeLoseCondition(losePanelView, _data, Container.Resolve<GameMachine>());
                timeLoseCondition.Subscribe();
            };
        }
    }
}