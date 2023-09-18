using System;
using WhackTheMole.Scripts.UI;
using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.Installers
{
    public class GameConditionInstaller : MonoInstaller
    {
        [SerializeField] private Transform container;
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
            var prefabs = Resources.LoadAll<PlayerDataViewBase>("Prefabs/Views");
            panelView.OnHpConditionEvent += () =>
            {
                var hpLoseCondition = new HpLoseCondition(losePanelView, _data, Container.Resolve<GameMachine>());
                hpLoseCondition.Subscribe();
                foreach (var viewBase in prefabs)
                {
                    if (viewBase is not (HealthView or ScoreView)) continue;
                    var view = Instantiate(viewBase, container);
                    Container.Inject(view);
                    view.OnStartGame();
                }
            };
            panelView.OnTimeConditionEvent += () =>
            {
                var timeLoseCondition = new TimeLoseCondition(losePanelView, _data, Container.Resolve<GameMachine>());
                timeLoseCondition.Subscribe();
                foreach (var viewBase in prefabs)
                {
                    if (viewBase is not (TimeView or ScoreView)) continue;
                    var view = Instantiate(viewBase, container);
                    Container.Inject(view);
                    view.OnStartGame();
                }
            };
        }
    }
}