using GrayCity.Control.Movement._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender : MonoBehaviour
{
    public LevelInstance level;
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
        Debug.Log("Enter Ender");
        if (other.GetComponent<PlayerMovement>()!= null)
        {
            Debug.Log("On Clear Level");
            level.OnLevelClear();
        }
    }
}
