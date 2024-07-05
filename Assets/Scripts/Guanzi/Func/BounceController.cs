using GrayCity.Control.Movement._Scripts;
using UnityEngine;

public class BounceController : MonoBehaviour
{
    private GameObject target; // 被弹跳的目标对象
    private float initialBounceVelocity; // 初始弹跳速度
    private bool isBouncing = false;
    private Vector3 originalParentPosition;
    private Transform originalParent;
    private float time; // 弹跳时间
    [SerializeField] private float gravity = 2f;

    private Rigidbody2D rb;
    private Vector2 _frameVelocity;

    // 初始化弹跳
    public void InitiateBounce(GameObject target, float bounceForce)
    {
        this.target = target;
        this.initialBounceVelocity = bounceForce;
        originalParent = target.transform.parent;
        originalParentPosition = originalParent.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, initialBounceVelocity);
        isBouncing = true;
        target.GetComponent<PlayerMovement>().IgnoringYSpeed = true;
        time = 0f;
    }

    void Update()
    {
        if (isBouncing)
        {
            // 控制弹跳轨迹
            time += Time.deltaTime;
            
            // transform.position = new Vector3(transform.position.x, originalParentPosition.y + newY, transform.position.z);
            _frameVelocity.y = Mathf.MoveTowards(rb.velocity.y, -40, gravity * Time.fixedDeltaTime);
            rb.velocity = _frameVelocity;
            
            target.transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            // 判断弹跳是否结束
            if (rb.velocity.y <= 3f)
            {
                isBouncing = false;
                EndBounce();
            }
        }
    }

    // 结束弹跳
    private void EndBounce()
    {
        // 将目标对象的父对象恢复为原始父对象
        target.transform.parent = originalParent;
        // 销毁弹跳控制器对象
        target.GetComponent<PlayerMovement>().IgnoringYSpeed = false;
        Debug.Log("End Bounce");
    }
}