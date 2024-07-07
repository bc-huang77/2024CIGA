using GrayCity.Control.Movement._Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UpSideDownComponent : ChangeComponent
{
    public float duration = 0.4f;
    public float interval = 1.0f;
    private float lastCallTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (base.bSelected)
        {
            float h = Input.GetAxis("Mouse ScrollWheel");
            if (math.abs(h) > 0)
            {
                if (Time.time - lastCallTime > interval)
                {
                    lastCallTime = Time.time;
                    FlipAllObjects();
                }
            }
        }
    }

    public void FlipAllObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("UpSideDownAble");
        foreach (GameObject obj in gameObjects)
        {
            StartCoroutine(FlipObject(obj, duration));
            //obj.transform.position = new Vector3(obj.transform.position.x, -obj.transform.position.y, obj.transform.position.z);

            //obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 180);
        }
        /*
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (obj.scene.isLoaded && obj.GetComponent<Camera>() == null)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, -obj.transform.position.y, obj.transform.position.z);

                obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 180);
            }
        }*/
    }

    private IEnumerator FlipObject(GameObject obj, float duration)
    {
        float elapsedTime = 0;
        Vector3 originalPosition = obj.transform.position;
        Quaternion originalRotation = obj.transform.rotation;

        Vector3 targetPosition = new Vector3(originalPosition.x, -originalPosition.y, originalPosition.z);

        //Quaternion targetRotation = Quaternion.Euler(180 - originalRotation.eulerAngles.x, originalRotation.eulerAngles.y, -originalRotation.eulerAngles.z);
        Quaternion targetRotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y + 180, obj.transform.eulerAngles.z + 180);

        if (obj.GetComponent<PlayerMovement>() != null)
        {
            obj.GetComponent<PlayerMovement>().enabled = false;
            obj.GetComponent<CapsuleCollider2D>().enabled = false;
            targetRotation = obj.transform.rotation;
        }

        Transform child = transform.Find("Hurt");
        if (child)
        {
            if(child.GetComponent<HurtObject>() != null)
            {
                obj.GetComponent<HurtObject>().enabled = false;
            }
        }

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            // 平滑插值位置和旋转
            obj.transform.position = Vector3.Lerp(originalPosition, targetPosition, progress);
            obj.transform.rotation = Quaternion.Lerp(originalRotation, targetRotation, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (child)
        {
            if (child.GetComponent<HurtObject>() != null)
            {
                obj.GetComponent<HurtObject>().enabled = true;
            }
        }

        if (obj.GetComponent<PlayerMovement>() != null)
        {
            obj.GetComponent<PlayerMovement>().enabled = true;
            obj.GetComponent<CapsuleCollider2D>().enabled = true;
        }

        obj.transform.position = targetPosition;
        obj.transform.rotation = targetRotation;
        yield return null;
    }
}
