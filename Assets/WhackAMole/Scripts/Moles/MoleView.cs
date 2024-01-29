using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace WhackTheMole.Scripts.Moles
{
    public class MoleView : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnClickEvent;
        public event Action<float> OnUpdateEvent;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }

        public void Update()
        {
            OnUpdateEvent?.Invoke(Time.deltaTime);
        }

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }
    }
}