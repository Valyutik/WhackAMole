using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.UI
{
    public class WinPanelView : MonoBehaviour
    {
        private PlayerData _scoreCounter;
        private GameMachine _machine;
        
        [Inject]
        private void Initialize(PlayerData scoreCounter, GameMachine machine)
        {
            gameObject.SetActive(false);
            _machine = machine;
            _scoreCounter = scoreCounter;
            _scoreCounter.OnWinEvent += Show;
        }

        private void OnDestroy()
        {
            _scoreCounter.OnWinEvent -= Show;
        }

        private void Show()
        {
            _machine.FinishGame();
            gameObject.SetActive(true);
        }
    }
}