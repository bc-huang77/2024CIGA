using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       AudioManager.GetInstance(); 
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

    public void SetCurrentMusic(GlobalEnums.SoundSource index)
    {
        AudioManager.instance.SetCurrentMusic(index);

    }

    public void PlaySoundEffect(GlobalEnums.SoundSource index)
    {
        AudioManager.instance.PlaySoundEffect(index);
        
    }

    public FadeAnimateController fadeController; // 目标 UI 图片组件


    public void OnPlayerDeath()
    {
        HandleFadeIn();        

    }
    public void OnLevelClear()
    {

    }

    public void ResetLevel()
    {
        HandleFadeOut();
        LevelManager.Instance.ResetLevel();
        HandleFadeIn();
    }


// 渐变不透明
    private void HandleFadeOut()
    {
        // 通过 GameObject 的名称或标签来查找目标 UI 图片组件
        fadeController = GameObject.Find("Image").GetComponent<FadeAnimateController>();
        if (fadeController == null)
        {
            return;
        }

        fadeController.StartFadeOut();


    }

// 渐变透明
    private void HandleFadeIn()
    {
        // 通过 GameObject 的名称或标签来查找目标 UI 图片组件
        fadeController = GameObject.Find("Image").GetComponent<FadeAnimateController>();
        if (fadeController == null)
        {
            return;
        }

        fadeController.StartFadeIn();

}

}