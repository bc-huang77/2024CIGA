using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectPrefab;
    public Stage stage;
    private GameObject currentObject;

    
    public void CreateObject(int index)
    {
        if (currentObject != null) return;
        currentObject = Instantiate(objectPrefab[index]);
        // UpdateObjectPosition();
    }

    // void Start()
    // {
    //     int indexBackGroundImg = 1;
    //     List<Vector3> cellCenters = stage.getGrid().getCellCenters();
        
    //     for (int i = 0; i < cellCenters.Count; i++)
    //     {
    //         CreateObject(indexBackGroundImg);
    //         currentObject.transform.position = cellCenters[i];
    //         currentObject = null;

    //     }


    // }
    void Update()
    {
        if (currentObject == null) return;

        // ����λ��
        UpdateObjectPosition();

        // ȷ�Ϸ���
        if (Input.GetMouseButtonDown(0)) // ������
        {
            Vector3 newPosition = currentObject.transform.position;
            if (stage.GetNearestCell(ref newPosition))
            {
                currentObject.transform.position = newPosition;
                currentObject = null; // ������ɣ��������
            }
            else
            {
                Destroy(currentObject); // ���ٶ���
                currentObject = null; // �������
            }

        }

        // ȡ������
        if (Input.GetMouseButtonDown(1)) // ����Ҽ�
        {
            Destroy(currentObject); // ���ٶ���
            currentObject = null; // �������
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SpriteSpinner spinner = currentObject.GetComponentInChildren<SpriteSpinner>();
            if(spinner != null)
            {
                spinner.Spin();
            }
        }
    }

    void UpdateObjectPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentObject.transform.position = mousePosition;
    }
}
