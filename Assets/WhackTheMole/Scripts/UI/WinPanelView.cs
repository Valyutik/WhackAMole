using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using Zenject;

namespace WhackTheMole.Scripts.UI
{
    public class WinPanelView : MonoBehaviour
    {
        private PlayerData _scoreCounter;
        
        [Inject]
        private void Initialize(PlayerData scoreCounter)
        {
            gameObject.SetActive(false);
            _scoreCounter = scoreCounter;
            _scoreCounter.OnWinEvent += Show;
        }

        private void OnDestroy()
        {
            _scoreCounter.OnWinEvent -= Show;
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}