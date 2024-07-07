using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleComponent : ChangeComponent
{
    private Transform target; 
    public Transform pivot;
    public float ScaleSpeed = 0.1f;
    
    private bool biggerSoundPlayed = false;
    private bool smallerSoundPlayed = false;
    

    private void Awake()
    {
        target = transform;
    }

    void Start()
    {
        
    }
    
    private float resetTimer = 0;
    private float resetTime = 0.7f;
    

    void Update()
    {
        if(base.bSelected)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                ScaleObject(target, pivot.position, 1 + ScaleSpeed * Time.deltaTime); // �Ŵ�
                if (!biggerSoundPlayed)
                {
                    // LevelInstance.Instance.PlaySoundEffect(GlobalEnums.SoundSource.Bigger);
                    biggerSoundPlayed = true;
                }
                resetTimer = 0;
            }
            else if (scroll < 0)
            {
                ScaleObject(target, pivot.position, 1 - ScaleSpeed * Time.deltaTime); // ��С
                if (!smallerSoundPlayed)
                {
                    // LevelInstance.Instance.PlaySoundEffect(GlobalEnums.SoundSource.Smaller);
                    smallerSoundPlayed = true;
                }
                resetTimer = 0;
            }
            else
            {
                resetTimer += Time.deltaTime;
                if (resetTimer > resetTime)
                {
                    biggerSoundPlayed = false;
                    smallerSoundPlayed = false;
                }
                
            }
        }
    }

    void ScaleObject(Transform obj, Vector3 pivot, float scaleFactor)
    {
        // ������������ڻ�׼���λ��
        Vector3 direction = obj.position - pivot;

        // ��������
        obj.localScale *= scaleFactor;

        // ���ź��λ��
        Vector3 newDirection = direction * scaleFactor;

        // ��������λ��
        obj.position = pivot + newDirection;
    }
}
