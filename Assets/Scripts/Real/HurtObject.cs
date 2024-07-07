using GrayCity.Control.Movement._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("Player Dead");
            other.GetComponent<PlayerMovement>().Dead();
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Level");
            for(int i = 0; i < gameObjects.Length; i++)
            {
                Debug.Log("found");
                LevelInstance level = gameObjects[i].GetComponent<LevelInstance>();
                if(level)
                {
                    level.GetComponent<LevelInstance>().ResetLevel();
                    return;
                }
            }
        }
    }
}
