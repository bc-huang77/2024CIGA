using System;
using GrayCity.Control.Movement._Scripts;
using UnityEngine;

public class FlowFunc : MonoBehaviour
{
    public float angleOffset = 0f; // 偏移角度
    public float flowSpeed = 2f; // 洋流的速度
    
    private PlayerMovement playerMovement;

    void OnTriggerStay2D(Collider2D other)
    {
        // 检查进入触发区域的对象是否是目标对象
        if (other.CompareTag("Player"))
        {
            if(playerMovement == null)
                playerMovement = other.GetComponent<PlayerMovement>();
            
            if(playerMovement != null)
                playerMovement.IsFlowing = true;
            
            
            // 获取物体本地 x 轴方向
            Vector2 localXAxis = transform.right;

            // 计算偏移角度的方向
            float angleInRadians = angleOffset * Mathf.Deg2Rad; // 将角度转换为弧度
            Vector2 offsetDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

            // 计算实际的洋流方向
            Vector2 flowDirection = localXAxis * offsetDirection.x + new Vector2(-localXAxis.y, localXAxis.x) * offsetDirection.y;

            // 计算洋流的位移
            Vector2 flowMovement = flowDirection.normalized * flowSpeed * Time.deltaTime;

            // 直接移动目标对象
            other.transform.position += (Vector3)flowMovement;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(playerMovement == null)
                playerMovement = other.GetComponent<PlayerMovement>();
            
            if(playerMovement != null)
                playerMovement.IsFlowing = false;
            
            // 离开触发区域时，将速度归零
            // other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}