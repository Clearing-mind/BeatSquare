using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Vector3 initialScale;
    [SerializeField] private float scaleSmaller;
    [SerializeField] private float scaleBigger;

    void Start()
    {
        initialScale = player.transform.localScale;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(player.GetComponent<PlayerMovement>().isFacingRight == true)
            {
                player.transform.localScale = new Vector2(initialScale.x * scaleSmaller, initialScale.y * scaleSmaller);
            }
            else
            {
                player.transform.localScale = new Vector2(-initialScale.x * scaleSmaller, initialScale.y * scaleSmaller);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PlayerMovement>().isFacingRight == true)
            {
                player.transform.localScale = new Vector2(initialScale.x * scaleBigger, initialScale.y * scaleBigger);
            }
            else
            {
                player.transform.localScale = new Vector2(-initialScale.x * scaleBigger, initialScale.y * scaleBigger);
            }
        }
    }
}
