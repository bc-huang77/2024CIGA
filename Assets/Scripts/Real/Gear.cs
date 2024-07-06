using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : ChangeableObject
{
    private RotateComponent RotateComponent;

    // Start is called before the first frame update
    void Start()
    {
        RotateComponent = GetComponent<RotateComponent>();
        RotateComponent.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Active()
    {
        state++;
        if(state == 1)
        {
            RotateComponent.enabled = true;
            currentChange = RotateComponent;
        }
    }

}
