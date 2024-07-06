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
        
        levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Music_sea);
        levelInstance.PlayMusicOnLoop();
        
        levelInstance.PlaySoundEffect(GlobalEnums.SoundSource.Water);
    }

}
