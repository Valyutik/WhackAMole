using System.Collections.Generic;
using UnityEngine;
using WhackTheMole.Scripts.GameMachines;

namespace WhackTheMole.Scripts.Grid
{
    public abstract class GridGeneratorBase : IGameStateListener
    {
        public IEnumerable<ICell> Cells => CellsList;
        
        protected readonly List<Cell> CellsList = new();
        protected readonly Cell CellPrefab;
        protected readonly Transform TransformParent;
        protected readonly int CellCount;

        protected GridGeneratorBase(Cell cellPrefab, Transform parent, int cellCount)
        {
            CellPrefab = cellPrefab;
            TransformParent = parent;
            CellCount = cellCount;
        }

        public void OnStartGame()
        {
            GenerateGrid();
        }

        protected abstract void GenerateGrid();
    }
}