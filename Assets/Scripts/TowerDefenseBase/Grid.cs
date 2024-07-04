using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;


public class Grid<T>
{
    private int width;
    private int height;
    private float cellSize;
    private T[,] gridArray;
    private Vector3 position;
    // NOTE:暂时把cellCenters和初始化方法放在Grid。这个功能应该在Spawner里比较好。
    private List<Vector3> cellCenters = new List<Vector3>();

    public List<Vector3> getCellCenters(){
        return cellCenters;
    }
    public Grid(int width, int height,float cellSize, Vector3 position)
    {
        // 这两个值决定了cell的个数
        this.width = width;
        this.height = height;

        // 这是cell大小的倍率
        this.cellSize = cellSize;

        // position 是grid的某一个角（作为原点）
        this.position = position;

        gridArray = new T[width, height];
    }
 
    public void DrawGrid()
    {
        for (int i = 0; i <= height; i++)
        {
            Debug.DrawLine(new Vector3(position.x, position.y - i * cellSize, 0), new Vector3(position.x + width * cellSize, position.y - i * cellSize, 0), Color.red, 100f);
        }
        for (int i = 0; i <= width; i++)
        {
            Debug.DrawLine(new Vector3(position.x + i * cellSize, position.y, 0), new Vector3(position.x + i * cellSize, position.y - height * cellSize, 0), Color.red, 100f);
        }
    }

    public void drawcenters()
    {

        for (int i = 0; i < cellCenters.Count; i++)
        {

        }

    }
    public void setCellCenters()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j <width; j++)
            {
                Debug.Log("1");
                cellCenters.Add(new Vector3( cellSize/2 + position.x +  j * cellSize, position.y -  cellSize / 2 - i * cellSize, 0));
            }
        }
    }




// 如果返回true就会把worldPositon设置为离他最近的cell的中心
    public bool GetNearestCell(ref Vector3 worldPosition)
    {
        
        if (worldPosition.x < position.x - cellSize || worldPosition.x > position.x + (width+1) * cellSize || worldPosition.y > position.y + cellSize || worldPosition.y < position.y - (height+1) * cellSize)
        {
            return false;
        }
        int x = Mathf.FloorToInt((worldPosition.x - position.x) / cellSize);
        int y = Mathf.FloorToInt((position.y - worldPosition.y) / cellSize);
        x = Mathf.Clamp(x, 0, width - 1);
        y = Mathf.Clamp(y, 0, height - 1);
        worldPosition =  new Vector3(position.x + x * cellSize + cellSize / 2, position.y - y * cellSize - cellSize / 2, 0);
        return true;
    }
}
