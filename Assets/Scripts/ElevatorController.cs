using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    
    private Animator Elevator;
    private bool hasCollided = false;
  
    private void Start()
    {
   
    // 获取动画组件
    Elevator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && !hasCollided)// 检测到与角色的碰撞
        {
          
            

            StartCoroutine(PlayAnimationWithDelay(2f)); // 启动协程延迟两秒后播放动画
            hasCollided = true;
        }
        
    }
    
    private IEnumerator PlayAnimationWithDelay(float delay)
    {

        yield return new WaitForSeconds(delay);// 等待指定的延迟时间
        Elevator.SetTrigger("ElevatorTrigger");
        Elevator.Play("Elevator-Animation", 0, 0f);


    }
    void Update()
    {
        
    }

     

    
    
}
