using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    public float jumpForce = 20f; // 跳跃的力大小
    private Animator padAnimator;

    private void Start()
    {
        // 获取动画组件
        padAnimator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))// 检测到与角色的碰撞
        {

            if (padAnimator != null)
            {
                padAnimator.SetTrigger("PlayAnimationTrigger");
                padAnimator.Play("Pad-Animation", 0, 0f);
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
         
        }
        
    }
    
}
