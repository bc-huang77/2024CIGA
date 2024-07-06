using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleComponent : ChangeComponent
{
    private Transform target; 
    public Transform pivot;
    public float ScaleSpeed = 0.1f;

    private void Awake()
    {
        target = transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(base.bSelected)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                ScaleObject(target, pivot.position, 1 + ScaleSpeed); // 放大
            }
            else if (scroll < 0)
            {
                ScaleObject(target, pivot.position, 1 - ScaleSpeed); // 缩小
            }
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
