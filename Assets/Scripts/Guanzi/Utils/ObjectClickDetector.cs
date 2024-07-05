using UnityEngine;

public class ObjectClickDetector : MonoBehaviour
{
    public Material glowMaterial; // 泛光材质
    private Material originalMaterial; // 原始材质
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material; // 保存原始材质
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键按下
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.transform == transform)
            {
                spriteRenderer.material = glowMaterial; // 切换到泛光材质
            }
            else
            {
                spriteRenderer.material = originalMaterial; // 恢复原始材质
            }
        }
    }
}