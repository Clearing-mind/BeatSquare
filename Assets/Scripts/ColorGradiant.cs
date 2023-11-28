using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    public float colorChangeDuration = 2f;
    public float recoveryDuration = 1f;
    public float rainbowDuration = 0.01f; // 五彩斑斓的时间
    public float hueSpeed = 5f; // HSV 颜色变化的速度
    public float saturation = 1f; // HSV 颜色的饱和度
    public float brightness = 1f; // HSV 颜色的亮度
    public float blinkFrequency = 10f; // 闪烁频率，即白色的闪烁次数每秒
    public int blinkCount = 2; // 闪烁次数

    private Color originalColor;
    private bool isTouched = false;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        // 启动时开始颜色渐变
        InvokeRepeating(nameof(ChangeColorGradually), 0f, 0.1f); // 每隔0.1秒执行一次以实现更平滑的渐变
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTouched)
        {
            // 触碰时改变颜色
            StartCoroutine(ChangeColorInstantlyRainbow());
            isTouched = true;

            // 在接触完成后，一定时间后恢复原始颜色
            Invoke(nameof(ResetColor), recoveryDuration);
        }
    }

    void ChangeColorInstantly(Color newColor)
    {
        // 瞬间改变颜色
        GetComponent<Renderer>().material.color = newColor;
    }

    System.Collections.IEnumerator ChangeColorInstantlyRainbow()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // 白色
            ChangeColorInstantly(Color.white);
            yield return new WaitForSeconds(1f / blinkFrequency);

            // 恢复原始颜色
            ChangeColorInstantly(originalColor);
            yield return new WaitForSeconds(1f / blinkFrequency);
        }
    }

    void ChangeColorGradually()
    {
        // 渐变颜色
        float t = Mathf.PingPong(Time.time / colorChangeDuration, 1f);
        Color lerpedColor = Color.Lerp(Color.red, Color.blue, t);
        GetComponent<Renderer>().material.color = lerpedColor;
    }

    void ResetColor()
    {
        // 恢复原始颜色
        ChangeColorInstantly(originalColor);
        isTouched = false;
    }

    // 提供接口设置五彩斑斓颜色的数据
    public void SetRainbowColorData(float newRainbowDuration, float newHueSpeed, float newSaturation, float newBrightness)
    {
        rainbowDuration = newRainbowDuration;
        hueSpeed = newHueSpeed;
        saturation = newSaturation;
        brightness = newBrightness;
    }
}