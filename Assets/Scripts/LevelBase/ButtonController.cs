using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button; // 引用按钮组件

    public bool isButtonClickable = true; // 控制按钮是否可点击的标志

    // 在 Start 方法中获取按钮组件，并初始化按钮的可点击状态
    private void Awake()
    {
        button = GetComponent<Button>();
        // button.interactable = isButtonClickable;
    }

    // 定义一个公共方法来更改按钮的可点击状态
    // Need Bool parameter 
    public void SetButtonInteractable(bool interactable)
    {
        isButtonClickable = interactable;
        button.interactable = isButtonClickable;
    }
}
