using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public CapsuleCreator parent;

    private Vector3 originalPosition;
    private bool isDragging = false; 
    public LayerMask droppableLayer;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            // 检测鼠标点击的物体
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject != gameObject) return;
                isDragging = true;
            }
        }

        // 检测鼠标左键抬起
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            // 检测鼠标抬起的位置是否在另一个物体上
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, droppableLayer);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                // 触发目标物体的效果
                ChangeableObject changeableObject = hit.collider.GetComponent<ChangeableObject>();
                if (changeableObject != null)
                {
                    changeableObject.Active();
                    parent.CreateCapsule();
                    Destroy(gameObject);

                }
            }

            // 将被拿起的物体恢复到原始位置
            transform.position = originalPosition;
            isDragging = false;
        }

        // 如果正在拖动物体
        if (isDragging)
        {
            // 更新物体位置到鼠标位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

}
