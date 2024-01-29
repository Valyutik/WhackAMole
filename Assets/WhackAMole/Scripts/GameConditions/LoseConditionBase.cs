using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.UI;

namespace WhackTheMole.Scripts.GameConditions
{
    public abstract class LoseConditionBase
    {
        protected readonly PlayerData Data;
        private readonly LosePanelView _losePanelView;
        private readonly GameMachine _machine;

        protected LoseConditionBase(LosePanelView losePanelView, PlayerData data, GameMachine machine)
        {
            _losePanelView = losePanelView;
            _machine = machine;
            _machine.StartGame();
            Data = data;
        }

        public abstract void Subscribe();

        protected void Lose()
        {
            _machine.FinishGame();
            _losePanelView.Show();
        }
    }
}