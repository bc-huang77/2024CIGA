using GrayCity.Control.Movement._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eddy : ChangeableObject
{
    public float power = 10;
    public float finalPower = 100;
    private float timer = 0.0f;
    private float direction = 1.0f;
    private float realFinalPower;
    // Start is called before the first frame update
    void Start()
    {
        realFinalPower = finalPower;
        finalPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = 0.0f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float dotProduct = Vector3.Dot(transform.forward, Vector3.up);

        if (dotProduct >= 0) 
        {
            direction = 1.0f;
        }
        else
        {
            direction = -1.0f;
        }
            timer += Time.deltaTime;
        PlayerMovement pm = other.GetComponent<PlayerMovement>();
        if(pm != null)
        {
            pm.SetYSpeed(direction  * timer * power);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timer += Time.deltaTime;
        PlayerMovement pm = other.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.SetYSpeed(direction * timer * finalPower);
        }
        timer = 0.0f;
    }

    public override void Active()
    {
        finalPower = realFinalPower;
    }

    public override void Select()
    {
        
    }

    public override void Deselect()
    {
        
    }
}
