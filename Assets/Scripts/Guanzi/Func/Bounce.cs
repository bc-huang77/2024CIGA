using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float baseBounceForce = 10f; // 基础弹跳力
    public string targetTag = "Player"; // 目标对象的标签
    public GameObject bounceControllerPrefab; // 用于弹跳的空游戏对象预制体

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞对象是否是目标对象
        if (collision.gameObject.CompareTag(targetTag))
        {
            // 获取目标的 Rigidbody2D
            Rigidbody2D targetRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (targetRb != null)
            {
                // 生成空的弹跳控制器对象
                GameObject bounceController = Instantiate(bounceControllerPrefab, transform.position, Quaternion.identity);
                
                // 将目标设置为弹跳控制器的子对象
                collision.transform.parent = bounceController.transform;

                // 启动弹跳控制器的弹跳逻辑
                BounceController controller = bounceController.GetComponent<BounceController>();
                if (controller != null)
                {
                    controller.InitiateBounce(collision.gameObject, baseBounceForce * transform.localScale.y);
                }
            }
        }
    }
}