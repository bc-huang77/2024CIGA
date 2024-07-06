using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // AudioManager 的单例
    

    public AudioSource audioSource; // 用于播放背景音乐的 AudioSource
    public AudioClip currentAudioClip;
    public List<AudioClip> audioClips;

    public List<AudioClip> clickEffects;
    private void Awake()
    {
        // 设置 AudioManager 的单例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
            GameObject audioSourceObject = new GameObject("audioSource");
            audioSourceObject.transform.SetParent(transform); // 设置为 AudioManager 对象的子对象
            audioSource = audioSourceObject.AddComponent<AudioSource>(); // 添加 AudioSource 组件
        }
        else
        {
            Destroy(gameObject);
        }
        // 创建一个空的游戏对象，用于承载 AudioSource 组件
    }

    public AudioManager GetAudioManager(){
        return instance;
    }
    // 播放背景音乐
    public void PlayMusic()
    {
        audioSource.Play();
    }
    public void PlayMusicOnLoop()
    {
        audioSource.loop = true;
        PlayMusic();
    }

    // 停止背景音乐
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void setCurrentMusic(int index)
    {
        audioSource.loop = false;
        audioSource.clip = audioClips[index];

    }
    
    public void onClickEffect(int index)
    {
        audioSource.PlayOneShot(clickEffects[index]);
    }





    // For test
    void Start()
    {
        setCurrentMusic(0);
        PlayMusic();
        

    }
}
