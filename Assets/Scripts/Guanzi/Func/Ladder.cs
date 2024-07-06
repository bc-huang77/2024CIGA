using GrayCity.Control.Movement._Scripts;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 5f; // 爬梯子的速度
    private PlayerMovement playerMovement;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerMovement == null)
        {
            playerMovement = other.GetComponent<PlayerMovement>();
        }
        if (other.CompareTag("Player"))
        {
            playerMovement.IgnoringYSpeed = true;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 禁用重力影响
                rb.gravityScale = 0f;

                // 获取玩家输入
                float verticalInput = Input.GetAxis("Vertical");

                // 计算垂直移动
                other.transform.Translate(Vector2.up * verticalInput * climbSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.IgnoringYSpeed = false;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 恢复重力影响
                rb.gravityScale = 1f;
            }
        }
    }
}