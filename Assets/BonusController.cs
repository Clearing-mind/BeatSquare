using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // ��ȡ AudioSource ���
        audioSource = GetComponent<AudioSource>();

        // ȷ�� AudioSource ���ڲ�������Ƶ�ļ�
        if (audioSource == null || audioSource.clip == null)
        {
            Debug.LogError("AudioSource or AudioClip not set.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ������������
            PlayAndDestroy();
        }
    }

    void PlayAndDestroy()
    {
        // ������Ƶ
        audioSource.Play();
        // ������ײ������ֹ�ٴδ���
        GetComponent<Collider2D>().enabled = false;
        // ����Э�̣�����Ƶ������Ϻ���������
        StartCoroutine(DestroyAfterSound());
    }

    IEnumerator DestroyAfterSound()
    {
        // �ȴ���Ƶ�������
        yield return new WaitForSeconds(audioSource.clip.length);
        // ��������
        Destroy(gameObject);
    }
}

