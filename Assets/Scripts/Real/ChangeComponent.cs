using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeComponent : MonoBehaviour
{
    protected bool bSelected = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Select()
    {
        bSelected = true;
    }

}
