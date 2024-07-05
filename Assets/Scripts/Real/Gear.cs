using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour, IChangeable
{
    public bool selected;
    public bool bCanZoomInAndOut;
    public float RotateSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            if(bCanZoomInAndOut)
            {
                //鼠标滚轮向前滚动则顺时针旋转，向后滚动则逆时针旋转
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                if (scroll != 0)
                {
                    Debug.Log("Mouse ScrollWheel: " + scroll);
                    transform.Rotate(Vector3.forward, scroll * RotateSpeed);
                    Invoke("HandleChangeOnce", 0.5f);
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
}
