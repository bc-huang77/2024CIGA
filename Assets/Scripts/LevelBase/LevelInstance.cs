using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelIndex)
    {
        LevelManager.Instance.LoadLevel(levelIndex);
    }

    public void PlayMusic()
    {
        AudioManager.instance.setCurrentMusic(1);
        AudioManager.instance.PlayMusic();
    }
    public void PlayMusicOnLoop()
    {
        AudioManager.instance.PlayMusicOnLoop();
    }

    // 停止背景音乐
    public void StopMusic()
    {
        AudioManager.instance.StopMusic();
    }

    public void setCurrentMusic(int index)
    {
        AudioManager.instance.setCurrentMusic(index);

    }
}
