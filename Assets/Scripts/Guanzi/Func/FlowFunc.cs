using UnityEngine;

public class Flow : MonoBehaviour
{
    public Vector2 flowDirection = new Vector2(1, 0); // 洋流的方向和速度
    public float flowSpeed = 2f; // 洋流的速度

    void OnTriggerStay2D(Collider2D other)
    {
        // 检查进入触发区域的对象是否是目标对象
        if (other.CompareTag("Player"))
        {
            // 计算洋流的位移
            Vector2 flowMovement = flowDirection.normalized * flowSpeed * Time.deltaTime;
            // 直接移动目标对象
            other.transform.position += (Vector3)flowMovement;
        }
    }
}