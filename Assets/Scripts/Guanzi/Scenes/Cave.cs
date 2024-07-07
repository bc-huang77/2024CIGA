using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    private LevelInstance _levelInstance;
    
    void Start()
    {
        _levelInstance = GetComponent<LevelInstance>();
        _levelInstance.StopMusic();
        
        _levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Cave);
        _levelInstance.PlayMusicOnLoop();

    }
    
}
