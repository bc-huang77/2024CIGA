using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    private LevelInstance _levelInstance;

    private void Start()
    {
        _levelInstance = GetComponent<LevelInstance>();
        _levelInstance.StopMusic();
        _levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Woods);
        _levelInstance.PlayMusicOnLoop();

    }
}
