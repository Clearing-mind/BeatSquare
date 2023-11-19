using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoBehaviour
{
    public ParticleSystem starParticles; // 将粒子系统拖拽到这个字段中
    public Transform player; // 将玩家角色的Transform拖拽到这个字段中
    public float activationDistance = 2f; // 触发粒子效果的距离阈值



    void Start()
    {
       
        starParticles = GetComponent<ParticleSystem>(); // 获取粒子系统的引用
        
        if (player == null)// 如果没有手动指定玩家角色，则默认使用脚本所在对象
        {
            player = transform;
        }
        
        if (starParticles != null)// 在开始时暂停粒子系统
        {
            starParticles.Pause();
        }
    }

    void Update()
    {
       
        TriggerParticleEffect(); // 在摄像机移动时触发粒子效果
        
        if (Vector2.Distance(transform.position, player.position) < activationDistance)// 在摄像机接近玩家时触发粒子效果
        {
            TriggerParticleEffect();
        }
    }

    void TriggerParticleEffect()
    {
        // 如果粒子系统存在并且未在播放，则播放粒子效果
        if (starParticles != null && !starParticles.isPlaying)
        {
            starParticles.Play();
        }
    }
}