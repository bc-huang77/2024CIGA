using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        LevelInstance.Instance.StopMusic();
        LevelInstance.Instance.SetCurrentMusic(GlobalEnums.SoundSource.Water);
        LevelInstance.Instance.PlayMusicOnLoop();
    }

}
