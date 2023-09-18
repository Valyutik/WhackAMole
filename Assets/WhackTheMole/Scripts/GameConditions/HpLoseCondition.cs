using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.UI;

namespace WhackTheMole.Scripts.GameConditions
{
    public class HpLoseCondition : LoseConditionBase
    {
        public HpLoseCondition(LosePanelView losePanelView, PlayerData data, GameMachine machine)
            : base(losePanelView, data, machine)
        {
        }

        public override void Subscribe()
        {
            Data.OnHpPlayerLostEvent += Lose;
        }
    }
}