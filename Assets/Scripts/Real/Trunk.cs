using UnityEngine;

public class Trunk : ChangeableObject
{
    private ScaleComponent scaleComponent;
    public Transform PortalA;
    public Transform PortalB;
    public GameObject platform;

    private Portal portalComponentA;
    private Portal portalComponentB;

    public float SizeLimit;
    // Start is called before the first frame update
    void Start()
    {
        scaleComponent = GetComponent<ScaleComponent>();
        scaleComponent.enabled = false;

        PortalA = transform.Find("PortalA");
        PortalB = transform.Find("PortalB");
        portalComponentA = PortalA.GetComponent<Portal>();
        portalComponentB = PortalB.GetComponent<Portal>();
        if (platform)
        {
            platform.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x >= SizeLimit)
        {
            portalComponentA.bEnoughSize = true;
            portalComponentB.bEnoughSize = true;
            if (platform)
            {
                platform.SetActive(true);
            }
        }
        else
        {
            portalComponentA.bEnoughSize = false;
            portalComponentB.bEnoughSize = false;
            if (platform)
            {
                platform.SetActive(false);
            }
        }
    }

    public override void Active()
    {
        state++;
        if (state == 1)
        {
            scaleComponent.enabled = true;
            currentChange = scaleComponent;
        }
    }

    public override void Select()
    {
        scaleComponent.Select();
    }
}
