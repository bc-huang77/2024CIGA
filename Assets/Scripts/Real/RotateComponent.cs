using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    private bool bSelected = false;
    public float RotateSpeed = 20.0f;
    private GameObject leftButton;
    private GameObject rightButton;

    public GameObject buttonPrefab;
    public Canvas canvas;
    void Update()
    {

    }

    public void Select()
    {
        bSelected = true;
        SpawnButtons();
    }

    public void Deselect()
    {
        bSelected = false;
        Destroy(leftButton);
        Destroy(rightButton);
    }

    private void SpawnButtons()
    {
        // 获取物体在屏幕空间的位置
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // 创建两个按钮，一个在左边，一个在右边
        leftButton = Instantiate(buttonPrefab, canvas.transform);
        leftButton.GetComponent<RectTransform>().position = new Vector3(screenPos.x - 50, screenPos.y, screenPos.z);
        leftButton.GetComponent<Button>().onClick.AddListener(() => OnRotateButtonClicked(false));

        rightButton = Instantiate(buttonPrefab, canvas.transform);
        rightButton.GetComponent<RectTransform>().position = new Vector3(screenPos.x + 50, screenPos.y, screenPos.z);
        rightButton.GetComponent<Button>().onClick.AddListener(() => OnRotateButtonClicked(true));
    }

    private void OnRotateButtonClicked(bool ClockWise)
    {
        if (ClockWise)
        {
            transform.Rotate(Vector3.forward, -RotateSpeed);
        }
        else
        {
            transform.Rotate(Vector3.forward, RotateSpeed);
        }
    }
}
