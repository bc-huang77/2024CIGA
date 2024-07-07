using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowMembers : ChangeableObject
{
    public GameObject image;
    
    public override void Active()
    {
        Debug.Log("Active");
        image.SetActive(true);
    }

    public override void Deselect()
    {
        // Debug.Log("Deselect");
    }
    
    public override void Select()
    {
        // Debug.Log("Select");
    }
}
