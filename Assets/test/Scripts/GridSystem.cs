using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject gridPrefab;
    public Transform gridOrigin;
    const int rows = 12, columns = 12;
    const float gridOffset = 1;

    private void Start()
    {
        CreateGrids();
    }

    public void CreateGrids()
    {
        for(int i=0; i<rows; i++)
        {
            float xOffset = i * gridOffset;
            for(int j=0; j<columns; j++)
            {
                float zOffset = j * gridOffset;
                Vector3 position = gridOrigin.position + new Vector3(xOffset, 0, zOffset);
                GameObject grid = Instantiate(gridPrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
