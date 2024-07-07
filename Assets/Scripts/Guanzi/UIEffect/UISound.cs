using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public void PlayUIEnterSound()
    {
        AudioManager.instance.PlaySoundEffect(GlobalEnums.SoundSource.Button_over);
    }
    
    public void PlayUIClickSound()
    {
        AudioManager.instance.PlaySoundEffect(GlobalEnums.SoundSource.Button_enter);
    }
    
}
