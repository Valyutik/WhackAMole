using TMPro;
using UnityEngine;
using WhackTheMole.Scripts.GameConditions;
using WhackTheMole.Scripts.GameMachines;
using Zenject;

namespace WhackTheMole.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class PlayerDataViewBase : MonoBehaviour, IGameStateListener
    {
        protected string DefaultText;
        protected PlayerData PlayerData;
        private TextMeshProUGUI _textMeshPro;

        [Inject]
        protected virtual void Initialize(PlayerData playerData)
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            PlayerData = playerData;
            gameObject.SetActive(false);
            Subscribe();
        }

        protected abstract void Subscribe();

        protected abstract void Unsubscribe();

        public void OnStartGame()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        protected void ChangeText(string text)
        {
            _textMeshPro.text = DefaultText + " " + text;
        }
    }
}