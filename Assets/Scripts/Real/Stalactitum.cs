using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactitum : ChangeableObject
{
    private MoveComponent MoveComponent;
    // Start is called before the first frame update
    void Start()
    {
        MoveComponent = GetComponent<MoveComponent>();
        MoveComponent.enabled = false;
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
            MoveComponent.enabled = true;
            currentChange = MoveComponent;
        }
    }

    public override void Select()
    {
        MoveComponent.Select();
    }
}
