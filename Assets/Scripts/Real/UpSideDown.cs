using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSideDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FlipAllObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipAllObjects()
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (obj.scene.isLoaded && obj.GetComponent<Camera>() == null)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, -obj.transform.position.y, obj.transform.position.z);

                obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 180);
            }
        }
    }
}
