using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour, IChangeable
{
    public bool selected;
    public bool bCanRotate;
    public bool bCanZoomInAndOut;
    public float ZoomSpeed = 1.0f;
    public float RotateSpeed = 20.0f;
    public GameObject buttonPrefab; 
    public Canvas canvas;

    private bool bHasSpawnedButtons = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            if(!bHasSpawnedButtons)
            {
                SpawnButtons();
                bHasSpawnedButtons = true;
            }

            if(bCanZoomInAndOut)
            {
                //鼠标滚轮向前滚动则顺时针旋转，向后滚动则逆时针旋转
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                if (scroll != 0)
                {
                    Debug.Log("Mouse ScrollWheel: " + scroll);
                    transform.localScale += new Vector3(scroll * ZoomSpeed, scroll * ZoomSpeed, 1);
                }
            }
        }

    }

    public void Change()
    {

    }

    private void HandleChangeOnce()
    {
        bCanZoomInAndOut = true;
    }

    private void SpawnButton(Vector3 screenPosition)
    {
        // 实例化按钮预制体
        GameObject buttonObj = Instantiate(buttonPrefab, canvas.transform);

        // 设置按钮位置
        buttonObj.GetComponent<RectTransform>().position = screenPosition;
    }

    private void SpawnButtons()
    {
        // 获取物体在屏幕空间的位置
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // 创建两个按钮，一个在左边，一个在右边
        SpawnButton(new Vector3(screenPos.x - 50, screenPos.y, screenPos.z)); // 左边的按钮，x 坐标偏移
        SpawnButton(new Vector3(screenPos.x + 50, screenPos.y, screenPos.z)); // 右边的按钮，x 坐标偏移
    }
}
