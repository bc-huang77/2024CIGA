using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : ChangeableObject
{
    private RotateComponent rotateComponent;

    private void Start()
    {
        rotateComponent = GetComponent<RotateComponent>();
        rotateComponent.enabled = false;
    }

    public override void Active()
    {
        state++;
        if (state == 1)
        {
            rotateComponent.enabled = true;
            currentChange = rotateComponent;
        }
    }

    public override void Select()
    {
        rotateComponent.Select();
    }
}
