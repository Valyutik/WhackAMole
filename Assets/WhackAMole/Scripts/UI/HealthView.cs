using WhackTheMole.Scripts.GameConditions;

namespace WhackTheMole.Scripts.UI
{
    public class HealthView : PlayerDataViewBase
    {
        protected override void Initialize(PlayerData playerData)
        {
            base.Initialize(playerData);
            ChangeText(PlayerData.Health.ToString());
        }

        protected override void Subscribe()
        {
            DefaultText = "Health:";
            PlayerData.OnChangeHealthEvent += ChangeText;
        }

        protected override void Unsubscribe()
        {
            PlayerData.OnChangeHealthEvent -= ChangeText;
        }
    }
}