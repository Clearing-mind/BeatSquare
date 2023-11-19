using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoBehaviour
{
    public ParticleSystem starParticles; // ������ϵͳ��ק������ֶ���
    public Transform player; // ����ҽ�ɫ��Transform��ק������ֶ���
    public float activationDistance = 2f; // ��������Ч���ľ�����ֵ



    void Start()
    {
       
        starParticles = GetComponent<ParticleSystem>(); // ��ȡ����ϵͳ������
        
        if (player == null)// ���û���ֶ�ָ����ҽ�ɫ����Ĭ��ʹ�ýű����ڶ���
        {
            player = transform;
        }
        
        if (starParticles != null)// �ڿ�ʼʱ��ͣ����ϵͳ
        {
            starParticles.Pause();
        }
    }

    void Update()
    {
       
        TriggerParticleEffect(); // ��������ƶ�ʱ��������Ч��
        
        if (Vector2.Distance(transform.position, player.position) < activationDistance)// ��������ӽ����ʱ��������Ч��
        {
            TriggerParticleEffect();
        }
    }

    void TriggerParticleEffect()
    {
        // �������ϵͳ���ڲ���δ�ڲ��ţ��򲥷�����Ч��
        if (starParticles != null && !starParticles.isPlaying)
        {
            starParticles.Play();
        }
    }
}