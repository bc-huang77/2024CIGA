using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glacier : MonoBehaviour
{
    private LevelInstance _levelInstance;

    private void Start()
    {
        _levelInstance = GetComponent<LevelInstance>();
        _levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Music_ice);
        _levelInstance.PlayMusicOnLoop();
        
        _levelInstance.PlaySoundEffect(GlobalEnums.SoundSource.Ice);
    }
}
