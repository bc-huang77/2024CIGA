using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{

    [SerializeField] private GameObject tipPrefab;
    // [SerializeField] private Transform targetPosi;

    private GameObject tipObject;
    private float timer = 0f;

    private void Start()
    {
        LevelInstance.Instance.StopMusic();
        LevelInstance.Instance.SetCurrentMusic(GlobalEnums.SoundSource.Woods);
        LevelInstance.Instance.PlayMusicOnLoop();

        if (tipPrefab != null)
        {
            tipObject = Instantiate(tipPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
            Debug.Log("Tip object instantiated successfully.");
        }
        else
        {
            Debug.LogError("tipPrefab is not assigned. Please assign a prefab in the inspector.");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) && timer > 3f)
        {
            if (tipObject != null)
            {
                Destroy(tipObject);
                Debug.Log("Tip object destroyed.");
            }
            else
            {
                Debug.LogWarning("Tip object is already destroyed or not instantiated.");
            }
        }
    }
}