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
    const int FORESTLEVEL = 3;
    const int CAVELEVEL = 4;
    const int OCEANLEVEL = 5;
    const int GLACIERLEVEL = 6;

    // Start is called before the first frame update
    void Start()
    {
        if (LevelManager.Instance.currentLevel == SELECTLEVEL)
        {
            // TODO: load 
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
        Debug.Log("PlayMusicOnLoop");
        AudioManager.instance.PlayMusicOnLoop();
    }

    // 停止背景音乐
    public void StopMusic()
    {
        AudioManager.instance.StopMusic();
    }

    public void SetCurrentMusic(GlobalEnums.SoundSource index)
    {
        Debug.Log("Set :" + index);
        AudioManager.instance.SetCurrentMusic(index);

    }

    public void PlaySoundEffect(GlobalEnums.SoundSource index)
    {
        Debug.Log(index);
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
        // HandleFadeIn();        
        ResetLevel();

    }
    // TODO: DELETE IT;
    // public void TestCaveClear()
    // {
    //     LevelManager.Instance.isCaveClear = true;
    //     LevelManager.Instance.isOcenaUnlocked = true;

    // }
    // public void TestUnlockCave()
    // {
    //     LevelManager.Instance.isCaveUnlocked = true;

    // }
    public void OnLevelClear()
    {
        int currentLevel = LevelManager.Instance.getCurrentLevelIndex();
        if (currentLevel == FORESTLEVEL)
        {
            // Sign pass and unlock next level
            LevelManager.Instance.isForestClear = true;
            LevelManager.Instance.isCaveUnlocked = true;
            
        }
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
        LoadLevel(SELECTLEVEL);

    }

    public void ResetLevel()
    {
        // TODO: FIX IT
        // HandleFadeOut();
        LevelManager.Instance.ResetLevel();
        // HandleFadeIn();
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
        GameObject forestButton = GameObject.Find("GotoForest");
        GameObject caveButton = GameObject.Find("GotoCave");
        GameObject oceanButton = GameObject.Find("GotoOcean");
        GameObject glacierButton = GameObject.Find("GotoGlacier");

        if (forestButton ||caveButton == null || oceanButton == null || glacierButton == null)
        {
            return;
        }
        LoadForestButton(forestButton);
        LoadCaveButton(caveButton);
        LoadOcenaButton(oceanButton);
        LoadGlacierButton(glacierButton);

    }

    private void LoadForestButton(GameObject forestButton)
    {
        ButtonController forestButtonController = forestButton.GetComponent<ButtonController>();
        bool isForestUnlocked = LevelManager.Instance.isForestUnlocked;
        forestButtonController.SetButtonInteractable(isForestUnlocked);
        if (isForestUnlocked)
        {
            if (LevelManager.Instance.isForestClear)
            {
                forestButton.GetComponent<ImgSwitcher>().SwitchImage();
            }

        }
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
                caveButton.GetComponent<ImgSwitcher>().SwitchImage();
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
                ocenaButton.GetComponent<ImgSwitcher>().SwitchImage();
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
                glacierButton.GetComponent<ImgSwitcher>().SwitchImage();
            }
        }

    }
    }
