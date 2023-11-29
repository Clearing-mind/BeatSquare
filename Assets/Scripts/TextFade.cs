using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Text组件引用
    public float fadeInTime = 2.0f; // 淡入时间
    public float fadeOutTime = 2.0f; // 淡出时间
    public float minAlpha = 0.0f; // 最小透明度
    public float maxAlpha = 1.0f; // 最大透明度

    void Start()
    {
        // 开始淡入效果
        textComponent = this.GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeTextToFullAlpha());
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, minAlpha);
        while (textComponent.color.a < maxAlpha)
        {
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, textComponent.color.a + (Time.deltaTime / fadeInTime));
            yield return null;
        }

        StartCoroutine(FadeTextToZeroAlpha());
    }

    public IEnumerator FadeTextToZeroAlpha()
    {
        while (textComponent.color.a > minAlpha)
        {
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, textComponent.color.a - (Time.deltaTime / fadeOutTime));
            yield return null;
        }

        StartCoroutine(FadeTextToFullAlpha());
    }
}
