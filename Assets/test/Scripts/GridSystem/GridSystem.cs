using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The grid system which implements the IGridSystem interface.
    /// Creates a certain number of grids, which are visible in the game view.
    /// 
    /// The IGridSystem interface exposes two methods in this class -> 
    /// One for retrieving the approx. center point of the grid (It's not precise) and the other for returning a random grid's position.
    /// 
    /// The rows and columns and the gridOffset could have been dynamic, but have been kept as constants, because of the box mesh(It's not of unit scale as of now) which encloses the grids.
    /// </summary>
    public class GridSystem : MonoBehaviour, IGridSystem
    {
        public Grid gridPrefab;
        public Transform gridOrigin;
        public BoxCollider gridCollider;
        private const int rows = 12, columns = 12;
        private const float gridOffset = 10;
        private Grid[,] grids;

        public BoxCollider GridCollider => gridCollider;

        public void Initialize()
        {
            CreateGrids();
        }

        private void CreateGrids()
        {
            grids = new Grid[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                float xOffset = i * gridOffset;
                for (int j = 0; j < columns; j++)
                {
                    float zOffset = j * gridOffset;
                    Vector3 position = gridOrigin.position + new Vector3(xOffset, 0, zOffset);
                    Grid grid = Instantiate(gridPrefab, position, Quaternion.identity, transform);
                    grid.Initialize();
                    grids[i, j] = grid;
                }
            }
        }

        public Vector3 CenterPoint()
        {
            return grids[rows / 2, columns / 2].transform.position;
        }

        public Vector3 RandomPoint()
        {
            int randomRow = Random.Range(0, rows - 1);
            int randomColumn = Random.Range(0, columns - 1);
            return grids[randomRow, randomColumn].transform.position;
        }
    }
}
