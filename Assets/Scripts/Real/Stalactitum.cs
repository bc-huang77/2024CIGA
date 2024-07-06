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
            MoveComponent.enabled = true;
            currentChange = MoveComponent;
        }
    }

    override public void Select()
    {
        Debug.Log("Stalactitum selected");
        selected = true;
        currentChange.Select();
    }
}
