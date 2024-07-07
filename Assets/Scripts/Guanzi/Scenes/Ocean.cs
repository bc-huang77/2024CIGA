using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    private LevelInstance levelInstance;

    // Start is called before the first frame update
    void Start()
    {
        levelInstance = GetComponent<LevelInstance>();
        levelInstance.StopMusic();
        levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Water);
        levelInstance.PlayMusicOnLoop();

    }

}
