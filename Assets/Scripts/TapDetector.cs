using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("isAttack01");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("isAttack02");
        }

        if (Input.GetKeyDown(KeyCode.Mouse3))
        {
            animator.SetTrigger("isAttack03");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("isKnockback");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(enemy, new Vector2(player.transform.position.x + 5.0f, player.transform.position.y), Quaternion.identity);
        }

    }
}
