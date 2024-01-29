using WhackTheMole.Scripts.GameMachines;
using WhackTheMole.Scripts.UI;

namespace WhackTheMole.Scripts.GameConditions
{
    public class TimeLoseCondition : LoseConditionBase 
    {
        public TimeLoseCondition(LosePanelView losePanelView, PlayerData data, GameMachine machine)
            : base(losePanelView, data, machine)
        {
        }

        public override void Subscribe()
        {
            Data.Timer.OnTimesUpEvent += Lose;
        }
    }
}