using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public CapsuleCreator parent;
    public MouseClickController mouseClickController;
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
        originalPosition = parent.transform.position;

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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, droppableLayer);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                ChangeableObject changeableObject = hit.collider.GetComponent<ChangeableObject>();
                if (changeableObject != null)
                {
                    Instantiate(particlePrefab, changeableObject.transform.position, Quaternion.identity);
                    LevelInstance.Instance.PlaySoundEffect(GlobalEnums.SoundSource.Glass_broken);
                    changeableObject.Active();
                    mouseClickController.AutoSelected(changeableObject);
                    parent.CreateCapsule();
                    Destroy(gameObject);

                }
            }

            transform.position = originalPosition;
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

}
