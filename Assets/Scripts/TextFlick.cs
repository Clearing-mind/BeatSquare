using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFlick : MonoBehaviour
{
    public float blinkSpeed;//闪烁速度
    private bool isAddAlpha = true;//是否增加透明度
    private float timer = 0;//计时器
    public float timeval = 1;//时间间隔

    private Text t;//指向自身图片
    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isAddAlpha)
        {
            t.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
                isAddAlpha = false;
                timer = 0;
            }
        }
        else
        {
            t.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
                isAddAlpha = true;
                timer = 0;
            }
        }
    }

}