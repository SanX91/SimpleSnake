using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour, IGridSystem
{
    public Grid gridPrefab;
    public Transform gridOrigin;
    public BoxCollider gridCollider;

    const int rows = 12, columns = 12;
    const float gridOffset = 10;
    Grid[,] grids;

    public BoxCollider GridCollider => gridCollider;

    public void Initialize()
    {
        CreateGrids();
    }

    void CreateGrids()
    {
        grids = new Grid[rows, columns];

        for (int i=0; i<rows; i++)
        {
            float xOffset = i * gridOffset;
            for(int j=0; j<columns; j++)
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
        return grids[rows / 2,columns / 2].transform.position;
    }

    public Vector3 RandomPoint()
    {
        int randomRow = Random.Range(0, rows - 1);
        int randomColumn = Random.Range(0, columns - 1);
        return grids[randomRow, randomColumn].transform.position;
    }
}
