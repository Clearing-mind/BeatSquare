using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePause : MonoBehaviour
{
    public TextMeshProUGUI pauseText; // 指定UI文本元素
    public GameObject timing;

    private void Awake()
    {
        // 游戏开始时暂停
        Time.timeScale = 0;
        pauseText.gameObject.SetActive(true);
    }

    private void Update()
    {
        // 检测玩家是否按下Enter键
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 恢复游戏并隐藏文本
            Time.timeScale = 1;
            timing.GetComponent<Timing>().startPlay = true;
            pauseText.gameObject.SetActive(false);
        }
    }
}
