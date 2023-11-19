using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TitleController))]
public class TitleController : MonoBehaviour
{
    public Animator TitleAnimator;
    public CanvasGroup canvasGroup;
    public float fadeOutDuration = 10f;

    void Start()
    {
        TitleAnimator.Play("title");// 在开始时播放动画
    }

    // 在动画结束时调用此方法
    public void OnAnimationEnd()
    {
     
        
        StartCoroutine(FadeOut());// 执行淡出效果
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeOutDuration);

            
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);// 插值透明度

            yield return null;
        }

       
    }
}