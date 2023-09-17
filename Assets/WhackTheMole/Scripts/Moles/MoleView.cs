using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WhackTheMole.Scripts.Moles
{
    public class MoleView : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnClickEvent;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}