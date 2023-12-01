using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] public bool takingDamage;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        takingDamage = false;
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().Respawn();
            this.gameObject.SetActive(false);
        }
    }

    public void TakenDamage()
    {
        //Debug.Log("Enemy Died !!!");
        takingDamage = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetTrigger("TakenDamage");
        Invoke("SetActiveFalse", 1.0f);
    }

    void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

}
