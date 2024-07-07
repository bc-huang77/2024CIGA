using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    
    void Start()
    {

        LevelInstance.Instance.StopMusic();
        
        LevelInstance.Instance.SetCurrentMusic(GlobalEnums.SoundSource.Cave);
        LevelInstance.Instance.PlayMusicOnLoop();

    }
    
}
