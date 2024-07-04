using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Grid<int> grid;
    public int width;
    public int height;
    public float cellSize;
    public GameObject imgPrefab;

    void Start()
    {
        //set an 3x3 grid at selvies position
        grid = new Grid<int>(width, height, cellSize, transform.position);
        grid.DrawGrid();
        grid.setCellCenters();
        List<Vector3> cellCenters = grid.getCellCenters();
        
        for (int i = 0; i < cellCenters.Count; i++)
        {
             GameObject prefabHandle;
             prefabHandle = Instantiate(imgPrefab);
             prefabHandle.transform.position = cellCenters[i];

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetNearestCell(ref Vector3 worldPositoin)
    {
        return grid.GetNearestCell(ref worldPositoin);
    }
    public Grid<int> getGrid(){
        return grid;
    }
}
