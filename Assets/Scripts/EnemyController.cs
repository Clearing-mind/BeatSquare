using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] public bool takingDamage;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        takingDamage = false;
    }

    public void TakenDamage()
    {
        //Debug.Log("Enemy Died !!!");
        takingDamage = true;
        animator.SetTrigger("TakenDamage");
        Invoke("SetActiveFalse", 1.0f);
    }

    void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

}
