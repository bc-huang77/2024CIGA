using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isForestUnlocked = false;
    public bool isForestClear = false;
    public bool isCaveUnlocked = false;
    public bool isCaveClear = false;
    public bool isOcenaUnlocked = false;
    public bool isOcenaClear = false;
    public bool isGlacierUnlocked = false;
    public bool isGlacierClear = false;
    public static LevelManager Instance { get; private set; }
    private bool isFirstTimeLoadManga = true;

    // ��ؿ����ݴ洢
    public int playerScore;
    public int currentLevel;
    private bool enableMange = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadManga(int mangaIndex)
    {
        currentLevel = mangaIndex;
        SceneManager.LoadScene(mangaIndex);
    }
    public void LoadLevel(int levelIndex)
    {


        if (!enableMange && levelIndex ==1)
        {
            levelIndex++;

        }


        // 当第一次 levelindex 为 1，也就是进入漫画场景时，走这个if
        if (enableMange)
        {
            enableMange = false;
        } 
        // WARRING: 上面两个if顺序不能变！！！！！！！！
        currentLevel = levelIndex;
        SceneManager.LoadScene(levelIndex);
        
        //Do something
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(currentLevel);

    }
    public int getCurrentLevelIndex()
    {
        return currentLevel;
    }
}
