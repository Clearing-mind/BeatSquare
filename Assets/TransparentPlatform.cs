using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlatform : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;

    public float disableDuration = 2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();

        // 启动循环
        StartCoroutine(PlatformLoop());
    }

    IEnumerator PlatformLoop()
    {
        while (true)
        {
            yield return FadeOut();
            yield return new WaitForSeconds(disableDuration);
            yield return FadeIn();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator FadeOut()
    {
        // 透明度突然变为 20%
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.18f);

        // 禁用 Collider2D
        platformCollider.enabled = false;

        yield return null;
    }

    IEnumerator FadeIn()
    {
        // 透明度突然变为 100%
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

        // 启用 Collider2D
        platformCollider.enabled = true;

        yield return null;
    }
}
