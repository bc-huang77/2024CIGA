using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ImgSwitcher : MonoBehaviour
{
    public UnityEngine.UI.Image imageComponent;
    public Sprite[] images;
    private int currentIndex = 0; 
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<UnityEngine.UI.Image> ();
        // 设置初始图片
        if (imageComponent != null && images.Length > 0)
        {
            Debug.Log(1);
            imageComponent.sprite = images[currentIndex];
        }
       
    }

    public void SwitchImage()
    {
        // 切换到下一个图片
        currentIndex = (currentIndex + 1) % images.Length;

        // 更新图片组件的图片
        if (imageComponent != null && images.Length > 0)
        {
            Debug.Log("test");
            imageComponent.sprite = images[currentIndex];
        }
    }
}
