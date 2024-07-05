using System;
using UnityEngine;

public class ScaleAroundPoint : MonoBehaviour
{
    private Transform target; // 需要放大的物体
    public Transform pivot;  // 基准点

    private void Awake()
    {
        target = transform;
    }

    void Update()
    {
        // 使用键盘输入检测放大和缩小
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ScaleObject(target, pivot.position, 1.1f); // 放大
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ScaleObject(target, pivot.position, 0.9f); // 缩小
        }
        
        //使用鼠标滚轮检测放大和缩小
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            ScaleObject(target, pivot.position, 1.1f); // 放大
        }
        else if (scroll < 0)
        {
            ScaleObject(target, pivot.position, 0.9f); // 缩小
        }
    }

    void ScaleObject(Transform obj, Vector3 pivot, float scaleFactor)
    {
        // 计算物体相对于基准点的位移
        Vector3 direction = obj.position - pivot;
        
        // 缩放物体
        obj.localScale *= scaleFactor;
        
        // 缩放后的位移
        Vector3 newDirection = direction * scaleFactor;
        
        // 更新物体位置
        obj.position = pivot + newDirection;
    }
}