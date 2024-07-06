using GrayCity.Control.Movement._Scripts;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float baseBounceForce = 10f; // 基础弹跳力
    public string targetTag = "Player"; // 目标对象的标签
    public GameObject bounceControllerPrefab; // 用于弹跳的空游戏对象预制体

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.Bounce(baseBounceForce * transform.localScale.y);
        }
        /*
        // 检查碰撞对象是否是目标对象
        if (collision.gameObject.CompareTag(targetTag))
        {
           
        }*/
    }
}