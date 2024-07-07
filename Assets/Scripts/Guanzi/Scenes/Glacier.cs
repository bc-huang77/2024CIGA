using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glacier : MonoBehaviour
{


    private void Start()
    {

        LevelInstance.Instance.StopMusic();
        LevelInstance.Instance.SetCurrentMusic(GlobalEnums.SoundSource.Ice);
        LevelInstance.Instance.PlayMusicOnLoop();

    }
}
