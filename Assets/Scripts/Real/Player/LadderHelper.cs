using GrayCity.Control.Movement._Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class LadderHelper : MonoBehaviour
{
    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            box.isTrigger = true;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            box.isTrigger = false;
        }
    }

}
