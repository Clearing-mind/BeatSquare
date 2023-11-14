using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 direction;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        height = this.transform.position.y;
    }

    void Update()
    {
        animator.SetFloat("speed", speed);

        distance = Vector2.Distance(this.transform.position, player.transform.position);
        direction = player.transform.position - this.transform.position;
        //Debug.Log(direction);

        if(direction.x < 0.0f)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        this.transform.position = new Vector2(this.transform.position.x, height);
    }
}
