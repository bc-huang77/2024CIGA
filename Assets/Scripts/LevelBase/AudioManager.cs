using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // AudioManager 的单例
       // 私有构造函数，防止通过 new 关键字创建实例
    private AudioManager()
    {
        // 执行初始化操作
    }

    // 公有静态方法，用于获取单例实例
    public static AudioManager GetInstance()
    {
        // 如果实例不存在，则创建新的实例
        if (instance == null)
        {
            // 创建一个不会被销毁的游戏对象
            GameObject audioManagerObject = new GameObject("AudioManager");
            DontDestroyOnLoad(audioManagerObject);

            // 添加 AudioManager 组件并赋值给 instance
            instance = audioManagerObject.AddComponent<AudioManager>();
        }

        return instance;
    } 

    public AudioSource audioSource; // 用于播放背景音乐的 AudioSource
    public AudioClip currentAudioClip;
    public List<AudioClip> audioClips;

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

    public void SetCurrentMusic(GlobalEnums.SoundSource index)
    {
        audioSource.loop = false;

        audioSource.clip = audioClips[(int)index];

    }
    
    public void PlaySoundEffect(GlobalEnums.SoundSource index)
    {
        audioSource.PlayOneShot(audioClips[(int)index]);
    }





    // For test
    void Start()
    {
        // PlaySoundEffect(GlobalEnums.SoundSource.Event);
        // SetCurrentMusic(0);
        // PlayMusic();
        

    }
}
