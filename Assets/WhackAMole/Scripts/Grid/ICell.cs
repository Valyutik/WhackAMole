using WhackTheMole.Scripts.Moles;
using UnityEngine;

namespace WhackTheMole.Scripts.Grid
{
    public interface ICell
    {
        Transform Transform { get; }
        void AddMole(Mole mole);
        bool CheckMole();
    }
}