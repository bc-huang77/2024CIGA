using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : ChangeComponent
{
    public float MoveSpeed = 1.0f;
    
    private bool soundPlayed = false;
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
            //move up or down
            transform.Translate( Vector3.up * h * MoveSpeed);
            if(h != 0 && !soundPlayed)
            {
                LevelInstance.Instance.PlaySoundEffect(GlobalEnums.SoundSource.Moving);
                soundPlayed = true;
            }
            else
            {
                soundPlayed = false;
            }
        }
    }
}
