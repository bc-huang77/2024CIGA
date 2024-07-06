using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    private LevelInstance _levelInstance;
    
    void Start()
    {
        _levelInstance = GetComponent<LevelInstance>();
        
        _levelInstance.SetCurrentMusic(GlobalEnums.SoundSource.Music_cave);
        _levelInstance.PlayMusicOnLoop();
        
        _levelInstance.PlaySoundEffect(GlobalEnums.SoundSource.Cave);
    }
    
}
