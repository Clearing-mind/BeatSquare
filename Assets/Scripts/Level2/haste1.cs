using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haste1 : MonoBehaviour
{
    Vector3 trans1;
    Vector2 trans2;
    public float zhenFu = 1f;
    public float HZ = 1f;
    public float speedMultiplier = 2f; // 加速倍数
    public float delayBeforeReset = 1f; // 重置速度的延迟时间
    public float scaleMultiplier = 1.5f; // 缩放倍数
    private void Awake()
    {
        trans1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;
        transform.position = trans2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 检测与 Player 的碰撞
        if (other.CompareTag("Player"))
        {
            // 获取 Player 的脚本
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // 应用加速效果
                playerMovement.SetSpeedMultiplier(speedMultiplier, delayBeforeReset); StartCoroutine(ScaleEffect());
            }
        }
    }
    IEnumerator ScaleEffect()
    {
        // 缩放效果：放大
        transform.localScale *= scaleMultiplier;
        yield return new WaitForSeconds(0.1f); // 调整持续时间，可以根据需要调整
        // 缩放效果：缩小
        transform.localScale /= scaleMultiplier;
    }
}
