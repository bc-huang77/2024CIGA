using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableObject : MonoBehaviour
{
    protected int state = 0;
    protected bool selected = false;
    virtual public void Active() { }
    virtual public void Select() { }
}
