    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using static UnityEditor.Searcher.SearcherWindow.Alignment;

    public class ElevatorController2 : MonoBehaviour
    {
        public float speed;
        public int startingPoint;
        public Transform[] points;
        private bool hasCollided = false;
        private int i;
        private PlayerMovement playerMovement;

    void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
    }

        void Update()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // 使用标签查找角色对象

            if (player != null && player.transform.position.x >= 1200)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

                if (playerMovement != null)
                {
                    playerMovement.EnableVerticalMovement();
                }
            }
            if (hasCollided)
            {
                if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
                {
                    i++;
                    if (i == points.Length)
                    {
                        i = points.Length - 1;
               
                    }
                
                }
                transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
            }

        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")  && i != points.Length - 1)
            {
                StartCoroutine(DelayedStart(2f)); // 启动协程延迟两秒
                collision.transform.SetParent(transform);

                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();// 获取角色的脚本
                if (playerMovement != null)
                {
                    // 禁用角色的垂直移动
                    playerMovement.DisableVerticalMovement();
                }
    
            }




    }

    /*{private void OnCollisionExit2D(Collision2D collision)
      {
          if (collision.collider.CompareTag("Player"))
          {
             collision.transform.SetParent(null);

         }



     }}*/


    private IEnumerator DelayedStart(float delay)
        {
            yield return new WaitForSeconds(delay);
            hasCollided = true; // 启用移动
        }



    }