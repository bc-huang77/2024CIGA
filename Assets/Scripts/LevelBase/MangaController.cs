using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaController : MonoBehaviour
{
    [System.Serializable]
    public struct UIImageData
    {
        public Image image;
        public Vector3 endPosition;
    }

    public UIImageData[] uiImages;  // 存储每个 UI 图片的数据
    public float flyInDuration = 1.0f;  // 飞入的持续时间

    private Vector3[] initialPositions;  // 存储每个 UI 图片的初始位置
    private Vector3[] flyInEndPositions;  // 存储每个 UI 图片的终点位置
    private float flyInTimer;  // 飞入的计时器

    private void Start()
    {
        // 存储初始位置
        initialPositions = new Vector3[uiImages.Length];
        for (int i = 0; i < uiImages.Length; i++)
        {
            initialPositions[i] = uiImages[i].image.rectTransform.position;
        }

        // 存储终点位置
        flyInEndPositions = new Vector3[uiImages.Length];
        for (int i = 0; i < uiImages.Length; i++)
        {
            flyInEndPositions[i] = uiImages[i].endPosition;
        }
    }

    private void Update()
    {
        // 更新飞入计时器
        flyInTimer += Time.deltaTime;

        // 计算当前的飞入进度（0 到 1）
        float progress = Mathf.Clamp01(flyInTimer / flyInDuration);

        // 更新每个 UI 图片的位置
        for (int i = 0; i < uiImages.Length; i++)
        {
            Vector3 startPosition = initialPositions[i];
            Vector3 endPosition = flyInEndPositions[i];
            uiImages[i].image.rectTransform.position = Vector3.Lerp(startPosition, endPosition, progress);
        }
    }
}