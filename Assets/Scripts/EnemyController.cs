using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public void TakeDamage()
    {
        Debug.Log("Enemy Died !!!");

        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
