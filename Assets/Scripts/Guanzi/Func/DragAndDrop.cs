using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 originalPosition; // 记录物体的原始位置
    private bool isDragging = false; // 记录是否正在拖动
    private GameObject currentObject; // 当前被拖动的物体
    public LayerMask droppableLayer; // 可投放目标的层级

    void Update()
    {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            // 检测鼠标点击的物体
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                currentObject = hit.collider.gameObject;
                originalPosition = currentObject.transform.position;
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
                // 触发目标物体的效果
                ChangeableObject changeableObject = hit.collider.GetComponent<ChangeableObject>();
                if (changeableObject != null)
                {
                    // 触发Change()方法
                }
            }

            // 将被拿起的物体恢复到原始位置
            currentObject.transform.position = originalPosition;
            isDragging = false;
            currentObject = null;
        }

        // 如果正在拖动物体
        if (isDragging && currentObject != null)
        {
            // 更新物体位置到鼠标位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, currentObject.transform.position.z);
        }
    }
}