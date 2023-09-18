using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace WhackTheMole.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButtonView : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(RestartScene);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
}