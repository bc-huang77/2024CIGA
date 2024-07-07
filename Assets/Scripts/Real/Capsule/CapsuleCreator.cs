using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CapsuleCreator : MonoBehaviour
{
    public List<Sprite> sprites;
    public MouseClickController mouseClickController;
    public int count = 3;
    public GameObject capsulePrefab;
    private Transform countDisplayer;
    private int max;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        max = count;
        countDisplayer = transform.Find("Text");
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        spriteRenderer.sprite = sprites[count];
        if (count > 0)
        {
            GameObject g = Instantiate(capsulePrefab, transform.position, transform.rotation, transform);
            Capsule c = g.GetComponent<Capsule>();
            c.parent = this;
            c.mouseClickController = mouseClickController;
            count--;
        }
    }
}
