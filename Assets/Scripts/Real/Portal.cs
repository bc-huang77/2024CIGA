using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject anotherPortal;
    public bool bActive = true;
    public bool bEnoughSize = false;
    public Transform portalCenter;
    public float a_time = 1.0f;
    public GameObject platform;

    private Portal anotherPortalComponent;
    private float activeTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anotherPortalComponent = anotherPortal.GetComponent<Portal>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!bEnoughSize)
        {
            return;
        }

        if (bActive)
        {
            if (other.tag == "Player")
            {
                anotherPortalComponent.bActive = false;
                other.transform.position = anotherPortalComponent.portalCenter.position;

            }
        }
        else
        {
            bActive = true;
            Debug.Log("re active");
            activeTime = Time.time;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!bEnoughSize)
        {
            return;
        }

        if (bActive)
        {

            if (Time.time - activeTime > a_time)
            {
                if (other.tag == "Player")
                {
                    anotherPortalComponent.bActive = false;
                    other.transform.position = anotherPortalComponent.portalCenter.position;
                }
            }
        }
    }

}
