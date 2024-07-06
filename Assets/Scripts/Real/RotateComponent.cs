using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateComponent : ChangeComponent
{
    public float RotateSpeed = 20.0f;
    public Transform pivot;
    private float radius;
    
    private bool soundPlayed = false;

    private void Start()
    {
        radius = Vector3.Distance(transform.position, pivot.position);
    }

    void Update()
    {
        //�����ֿ�����ת
        if (base.bSelected)
        {
            float h = Input.GetAxis("Mouse ScrollWheel");

            //transform.Rotate(Vector3.forward, h * RotateSpeed);

            transform.RotateAround(pivot.position, Vector3.forward, RotateSpeed * h);
            
            if (!soundPlayed)
            {
                LevelInstance.Instance.PlaySoundEffect(GlobalEnums.SoundSource.Rotate);
                soundPlayed = true;
            }
        }
        else
        {
            soundPlayed = false;
        }
    }

}
