using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private float height;
    [SerializeField] private float timeLimit;
    [SerializeField] private float countUp;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Vector2 initialScale;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = this.GetComponent<Animator>();
        height = player.transform.position.y;
        initialScale = this.transform.localScale;
    }

    void Update()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        direction = player.transform.position - this.transform.position;
        //Debug.Log(direction);

        countUp += Time.deltaTime;

        if (countUp >= timeLimit)
        {
            countUp = timeLimit;
            speed = player.GetComponent<PlayerMovement>().speed;
        }
        else
        {
            speed = distance / (timeLimit - countUp);
        }

        //animator.SetFloat("speed", speed);

        if (direction.x < 0.0f)
        {
            this.transform.localScale = new Vector3(initialScale.x, initialScale.y, 1.0f);
        }
        else
        {
            this.transform.localScale = new Vector3(-initialScale.x, initialScale.y, 1.0f);
        }

        this.transform.position = new Vector2(this.transform.position.x, height);

        if(this.GetComponent<EnemyController>().takingDamage == false)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
