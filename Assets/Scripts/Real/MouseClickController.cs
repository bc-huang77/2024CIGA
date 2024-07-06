using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseClickController : MonoBehaviour
{
    ChangeableObject currentSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                GameObject go = hit.collider.gameObject;
                if(go.GetComponent<ChangeableObject>() != null)
                {
                    ChangeableObject changeableObject = go.GetComponent<ChangeableObject>();
                    if(currentSelected != null)
                    {
                        currentSelected.Deselect();
                    }
                    changeableObject.Select();
                    currentSelected = changeableObject;
                    return;
                }

                if (go.GetComponent<Capsule>() != null)
                {
                    Capsule capsule = go.GetComponent<Capsule>();
                    capsule.StartDragging();
                }
            }
            else
            {
                if (currentSelected != null)
                {
                    currentSelected.Deselect();
                    currentSelected = null;
                }
            }
        }
    }

    public void AutoSelected(ChangeableObject obj)
    {
        currentSelected = obj;
        obj.Select();
    }
}
