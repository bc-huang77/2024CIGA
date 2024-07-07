using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CapsuleCreator : MonoBehaviour
{
    public MouseClickController mouseClickController;
    public int count = 3;
    public GameObject capsulePrefab;
    private Transform countDisplayer;
    private int max;
    // Start is called before the first frame update
    void Start()
    {
        max = count;
        countDisplayer = transform.Find("Text");
        CreateCapsule();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCapsule()
    {
        if (countDisplayer != null)
        {
            TextMeshPro tmp = countDisplayer.GetComponent<TextMeshPro>();

            if (tmp != null)
            {
                tmp.text = "Remain Capsule:" + count.ToString();
            }
 
        }

        if (count > 0)
        {
            GameObject g = Instantiate(capsulePrefab, transform.position, Quaternion.identity);
            Capsule c = g.GetComponent<Capsule>();
            c.parent = this;
            c.mouseClickController = mouseClickController;
            count--;
        }
    }
}
