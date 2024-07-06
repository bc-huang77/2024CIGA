using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheScene : ChangeableObject
{
    private UpSideDownComponent upSideDownComponent;
    // Start is called before the first frame update
    void Start()
    {
        upSideDownComponent = GetComponent<UpSideDownComponent>();
        upSideDownComponent.enabled = false;
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
            upSideDownComponent.enabled = true;
            currentChange = upSideDownComponent;
        }
    }
}
