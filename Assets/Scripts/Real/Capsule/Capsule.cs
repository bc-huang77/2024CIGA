using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public CapsuleCreator parent;

    private Vector3 originalPosition;
    private bool isDragging = false; 
    public LayerMask droppableLayer;
    private GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        particlePrefab = Resources.Load<GameObject>("Prefabs/ActiveParticle");
    }

    // Update is called once per frame
    void Update()
    {
        // �������������
        if (Input.GetMouseButtonDown(0))
        {
            // ��������������
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject != gameObject) return;
                isDragging = true;
            }
        }

        // ���������̧��
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            // ������̧���λ���Ƿ�����һ��������
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, droppableLayer);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                // ����Ŀ�������Ч��
                ChangeableObject changeableObject = hit.collider.GetComponent<ChangeableObject>();
                if (changeableObject != null)
                {
                    Instantiate(particlePrefab, changeableObject.transform.position, Quaternion.identity);
                    changeableObject.Active();
                    parent.CreateCapsule();
                    Destroy(gameObject);

                }
            }

            // �������������ָ���ԭʼλ��
            transform.position = originalPosition;
            isDragging = false;
        }

        // ��������϶�����
        if (isDragging)
        {
            // ��������λ�õ����λ��
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

}
