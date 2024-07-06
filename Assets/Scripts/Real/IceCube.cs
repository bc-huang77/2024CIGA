using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : ChangeableObject
{
    private RotateComponent rotateComponent;
    private ScaleComponent scaleComponent;
    // Start is called before the first frame update
    void Start()
    {
        rotateComponent = GetComponent<RotateComponent>();
        rotateComponent.enabled = false;
        scaleComponent = GetComponent<ScaleComponent>();
        scaleComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Active()
    {
        state++;
        if (state == 1)
        {
            rotateComponent.enabled = true;
            currentChange = rotateComponent;
        }
        else if(state == 2)
        {
            rotateComponent.enabled = false;
            scaleComponent.enabled = true;
            currentChange = scaleComponent;
        }
    }

}
