using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : ChangeableObject
{
    private ScaleComponent scaleComponent;

    // Start is called before the first frame update
    void Start()
    {
        scaleComponent = GetComponent<ScaleComponent>();
        scaleComponent.enabled = false;
        Active();
        Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Active()
    {
        state++;
        if (state == 1)
        {
            scaleComponent.enabled = true;
            currentChange = scaleComponent;
        }
    }

    override public void Select()
    {
        selected = true;
        currentChange.Select();
    }

}
