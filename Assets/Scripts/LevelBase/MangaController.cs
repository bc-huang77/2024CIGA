using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaController : MonoBehaviour
{
    [System.Serializable]
    public struct GameObjectData
    {
        public GameObject gameObject;
        public Vector3 initialPosition;
        public Vector3 endPosition;
        public bool hasFlown;  // 标记物体是否已经飞行过
    }

    public GameObjectData[] gameObjects;  // 存储每个游戏物体的数据
    public float flyInDuration = 1.0f;  // 飞入的持续时间

    private float flyInTimer;  // 飞入的计时器
    private int currentObjectIndex;  // 当前需要飞行的物体索引

    private bool canFly = false;
    private void Update()
    {
        if (canFly)
        {

            // 更新飞入计时器
            flyInTimer += Time.deltaTime;

            // 计算当前的飞入进度（0 到 1）
            float progress = Mathf.Clamp01(flyInTimer / flyInDuration);

            // 更新当前需要飞行的物体的位置
            if (currentObjectIndex < gameObjects.Length && !gameObjects[currentObjectIndex].hasFlown)
            {
                Vector3 startPosition = gameObjects[currentObjectIndex].initialPosition;
                Vector3 endPosition = gameObjects[currentObjectIndex].endPosition;
                gameObjects[currentObjectIndex].gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, progress);

                // 检查物体是否已经完成飞行
                if (progress >= 1.0f)
                {
                    gameObjects[currentObjectIndex].hasFlown = true;
                    currentObjectIndex++;
                    canFly = false;
                }
            }
        }
    }

    // 飞行一个物体
    public void FlyObject()
    {
        canFly = true;
        if (currentObjectIndex < gameObjects.Length && !gameObjects[currentObjectIndex].hasFlown)
        {
            // 重置飞行计时器
            flyInTimer = 0f;
        }
    }
}