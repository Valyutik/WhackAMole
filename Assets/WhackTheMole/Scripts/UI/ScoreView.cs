using UnityEngine;
using TMPro;

namespace WhackTheMole.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : PlayerDataViewBase
    {
        protected override void Subscribe()
        {
            DefaultText = "Score:";
            PlayerData.OnScoreChangeEvent += ChangeText;
        }

        protected override void Unsubscribe()
        {
            PlayerData.OnScoreChangeEvent += ChangeText;
        }
    }
}