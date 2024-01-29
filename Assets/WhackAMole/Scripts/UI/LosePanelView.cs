using UnityEngine;
using Zenject;

namespace WhackTheMole.Scripts.UI
{
    public class LosePanelView : MonoBehaviour
    {
        [Inject]
        private void Initialize()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}