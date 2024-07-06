using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableObject : MonoBehaviour
{

    protected int state = 0;
    protected bool selected = false;
    protected ChangeComponent currentChange;
    virtual public void Active() { }
    virtual public void Select() {
        selected = true;
        if (currentChange != null)
        {
            currentChange.Select();
        }
    }

    virtual public void Deselect()
    {
        selected = false;
        if (currentChange != null)
        {
            currentChange.Deselect();
        }
    }
}
