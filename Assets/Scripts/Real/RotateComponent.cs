using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateComponent : ChangeComponent
{
    public float RotateSpeed = 20.0f;
    public Transform pivot;
    private float radius;

    private void Start()
    {
        radius = Vector3.Distance(transform.position, pivot.position);
    }

    void Update()
    {
        //Êó±ê¹öÂÖ¿ØÖÆÐý×ª
        if (base.bSelected)
        {
            float h = Input.GetAxis("Mouse ScrollWheel");

            //transform.Rotate(Vector3.forward, h * RotateSpeed);

            transform.RotateAround(pivot.position, Vector3.forward, RotateSpeed * h);
        }
    }

}
