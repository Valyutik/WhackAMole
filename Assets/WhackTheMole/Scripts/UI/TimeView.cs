using WhackTheMole.Scripts.GameConditions;

namespace WhackTheMole.Scripts.UI
{
    public class TimeView : PlayerDataViewBase
    {
        protected override void Initialize(PlayerData playerData)
        {
            base.Initialize(playerData);
            ChangeText(PlayerData.Timer.Time.ToString("0.0"));
        }

        protected override void Subscribe()
        {
            DefaultText = "Time:";
            PlayerData.OnChangePlayTimeEvent += ChangeText;
        }

        protected override void Unsubscribe()
        {
            
            PlayerData.OnChangePlayTimeEvent += ChangeText;
        }
    }
}