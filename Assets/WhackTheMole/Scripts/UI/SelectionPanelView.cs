using System;
using UnityEngine;

namespace WhackTheMole.Scripts.UI
{
    public class SelectionPanelView : MonoBehaviour
    {
        public event Action OnHpConditionEvent, OnTimeConditionEvent;

        public void SetHpCondition()
        {
            OnHpConditionEvent?.Invoke();
            Hide();
        }

        public void SetTimeCondition()
        {
            OnTimeConditionEvent?.Invoke();
            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}