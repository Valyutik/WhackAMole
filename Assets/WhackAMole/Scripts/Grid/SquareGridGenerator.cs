using UnityEngine;

namespace WhackTheMole.Scripts.Grid
{
    public class SquareGridGenerator : GridGeneratorBase
    {
        public SquareGridGenerator(Cell cellPrefab, Transform parent, int cellCount)
            : base(cellPrefab, parent, cellCount)
        {
        }
        
        protected override void GenerateGrid()
        {
            var center = (CellCount - 1) / 2f;
            var gridCenter = new Vector3(center, 0, center);

            for (var i = 0; i < CellCount; i++)
            {
                for (var j = 0; j < CellCount; j++)
                {
                    var position = new Vector3Int(i, 0, j) - gridCenter;
                    var cell = 
                        Object.Instantiate(CellPrefab, position, Quaternion.identity, TransformParent);
                    cell.Initialize();
                    CellsList.Add(cell);
                }
            }
        }
    }
}