using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour, IChangeable
{
    private bool bCanZoomInAndOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int times)
    {
        Debug.Log("Gear changed " + times + " times");
    }

    private void HandleChangeOnce()
    {
        bCanZoomInAndOut = true;
    }
}
