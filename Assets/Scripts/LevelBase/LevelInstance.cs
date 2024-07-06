using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    public static LevelInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    const int SELECTLEVEL = 2;
    const int CAVELEVEL = 3;
    const int OCEANLEVEL = 4;
    const int GLACIERLEVEL = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (LevelManager.Instance.currentLevel == SELECTLEVEL)
        {
            LoadButton();
        }
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

    public void LoadManga(int mangaIndex)
    {
        LevelManager.Instance.LoadManga(mangaIndex);
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

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        AudioManager.instance.SetMusicVolume(volume);
    }

    public void SetEffectVolume(float volume)
    {
        Debug.Log(volume);
        AudioManager.instance.SetEffectVolume(volume);
    }
    public FadeAnimateController fadeController; // 目标 UI 图片组件


    public void OnPlayerDeath()
    {
        HandleFadeIn();        

    }
    // TODO: DELETE IT;
    public void TestCaveClear()
    {
        LevelManager.Instance.isCaveClear = true;
        LevelManager.Instance.isOcenaUnlocked = true;

    }
    public void TestUnlockCave()
    {
        LevelManager.Instance.isCaveUnlocked = true;

    }
    public void OnLevelClear()
    {
        int currentLevel = LevelManager.Instance.getCurrentLevelIndex();
        if (currentLevel == CAVELEVEL)
        {
            // Sign pass and unlock next level
            LevelManager.Instance.isCaveClear = true;
            LevelManager.Instance.isOcenaUnlocked = true;
            
        }
        
        if (currentLevel == OCEANLEVEL)
        {
            // Sign pass and unlock next level
            LevelManager.Instance.isOcenaClear = true;
            LevelManager.Instance.isGlacierUnlocked = true;
            
        }
        if (currentLevel == GLACIERLEVEL)
        {
            // Sign pass and unlock next level
            LevelManager.Instance.isGlacierClear = true;
            // LevelManager.Instance.isOcenaUnlocked = true;
            // TODO: how to go to end title
            
        }

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
    public void LoadButton()
    {
        GameObject caveButton = GameObject.Find("GotoCave");
        GameObject oceanButton = GameObject.Find("GotoOcean");
        GameObject glacierButton = GameObject.Find("GotoGlacier");

        if (caveButton == null || oceanButton == null || glacierButton == null)
        {
            return;
        }

        LoadCaveButton(caveButton);
        LoadOcenaButton(oceanButton);
        LoadGlacierButton(glacierButton);

    }

    private void LoadCaveButton(GameObject caveButton)
    {
        ButtonController caveButtonController = caveButton.GetComponent<ButtonController>();
        bool isCaveUnlocked = LevelManager.Instance.isCaveUnlocked;
        caveButtonController.SetButtonInteractable(isCaveUnlocked);
        if (isCaveUnlocked)
        {
            if (LevelManager.Instance.isCaveClear)
            {
                // TODO: switch img
                caveButton.GetComponent<ImgSwitcher>().SwitchImage();
                Debug.Log(5);
            }

        }
    }
    private void LoadOcenaButton(GameObject ocenaButton)
    {
        ButtonController ocenaButtonController = ocenaButton.GetComponent<ButtonController>();
        bool isOcenaUnlocked = LevelManager.Instance.isOcenaUnlocked;
        ocenaButtonController.SetButtonInteractable(isOcenaUnlocked);
        if (isOcenaUnlocked)
        {
            if (LevelManager.Instance.isOcenaClear)
            {
                // TODO: switch img
                Debug.Log(5);
            }

        }
    }
    private void LoadGlacierButton(GameObject glacierButton)
    {
        ButtonController glacierButtonController = glacierButton.GetComponent<ButtonController>();
        bool isGlacierUnlocked = LevelManager.Instance.isGlacierUnlocked;
        glacierButtonController.SetButtonInteractable(isGlacierUnlocked);
        if (isGlacierUnlocked)
        {
            if (LevelManager.Instance.isGlacierClear)
            {
                // TODO: switch img
                Debug.Log(5);
            }

        }
    }
}