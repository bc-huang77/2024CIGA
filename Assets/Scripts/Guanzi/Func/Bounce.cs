using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float baseBounceForce = 10f; // 基础弹跳力
    public string targetTag = "Player"; // 目标对象的标签，可以通过此脚本应用到不同对象

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞对象是否是目标对象
        if (collision.gameObject.CompareTag(targetTag))
        {
            Rigidbody2D targetRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (targetRb != null)
            {
                // 根据物体的缩放大小调整弹跳力
                float scaleFactor = transform.localScale.y;
                float bounceForce = baseBounceForce * scaleFactor;

                // 应用弹跳力到目标对象
                targetRb.velocity = new Vector2(targetRb.velocity.x, bounceForce);
            }
        }
    }
}