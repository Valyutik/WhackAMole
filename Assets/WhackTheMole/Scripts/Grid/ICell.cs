using UnityEngine;
using WhackTheMole.Scripts.Moles;

namespace WhackTheMole.Scripts.Grid
{
    public interface ICell
    {
        Transform Transform { get; }
        void AddMole(Mole mole);
        bool CheckMole();
    }
}