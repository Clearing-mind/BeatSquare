using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChecker : MonoBehaviour
{
    public GameObject player;
    public GameObject[] scales;
    public int playerScale;
    private int lastPlayerScale;

    void Start()
    {
        ResetScalesColor();
    }

    void Update()
    {
        playerScale = (int)Mathf.Abs(player.transform.localScale.x);

        if (playerScale != lastPlayerScale)
        {
            ResetScalesColor();
            scales[playerScale - 6].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            lastPlayerScale = playerScale;
        }

        switch (playerScale)
        {
            case 6:
                player.GetComponent<PlayerMovement>().jumpingPower = 12.0f;
                break;
            case 7:
                player.GetComponent<PlayerMovement>().jumpingPower = 14.0f;
                break;
            case 8:
                player.GetComponent<PlayerMovement>().jumpingPower = 16.0f;
                break;
            case 9:
                player.GetComponent<PlayerMovement>().jumpingPower = 18.0f;
                break;
            case 10:
                player.GetComponent<PlayerMovement>().jumpingPower = 20.0f;
                break;
            default:
                break;
        }
    }

    private void ResetScalesColor()
    {
        for (int i = 0; i < scales.Length; i++)
        {
            scales[i].GetComponent<SpriteRenderer>().color = new Color32(77, 77, 77, 255);
        }
    }
}
