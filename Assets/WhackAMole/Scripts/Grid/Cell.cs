using WhackTheMole.Scripts.Moles;
using UnityEngine;

namespace WhackTheMole.Scripts.Grid
{
    public class Cell : MonoBehaviour, ICell
    {
        public Transform Transform { get; private set; }
        private Mole _currentMole;

        public void Initialize()
        {
            Transform = transform;
        }

        public void AddMole(Mole mole)
        {
            _currentMole = mole;
        }

        public bool CheckMole()
        {
            return _currentMole == null;
        }
    }
}