using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float offsetX;
    public float randomY;
    public GameObject[] enemyPoints;
    private bool[] spawned;

    void Start()
    {
        spawned = new bool[enemyPoints.Length];
    }
    void Update()
    {
        randomY = UnityEngine.Random.Range(player.transform.position.y, player.transform.position.y + 10.0f);

        if (Input.GetKeyDown(KeyCode.P) && this.GetComponent<Timing>().onPlay == true)
        {
            Instantiate(enemy, new Vector3(player.transform.position.x + offsetX, randomY, 0.0f), Quaternion.identity);
        }

        for (int i = 0; i < enemyPoints.Length; i++)
        {
            if (!spawned[i] && player.transform.position.x > enemyPoints[i].transform.position.x)
            {
                Instantiate(enemy, new Vector3(player.transform.position.x + offsetX, randomY, 0.0f), Quaternion.identity);
                spawned[i] = true; 
            }
        }

    }
}
