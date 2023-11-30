using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // 获取 AudioSource 组件
        audioSource = GetComponent<AudioSource>();

        // 确保 AudioSource 存在并且有音频文件
        if (audioSource == null || audioSource.clip == null)
        {
            Debug.LogError("AudioSource or AudioClip not set.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 触发声音播放
            PlayAndDestroy();
        }
    }

    void PlayAndDestroy()
    {
        // 播放音频
        audioSource.Play();
        // 禁用碰撞器，防止再次触发
        GetComponent<Collider2D>().enabled = false;
        // 启动协程，在音频播放完毕后销毁物体
        StartCoroutine(DestroyAfterSound());
    }

    IEnumerator DestroyAfterSound()
    {
        // 等待音频播放完毕
        yield return new WaitForSeconds(audioSource.clip.length);
        // 销毁物体
        Destroy(gameObject);
    }
}

