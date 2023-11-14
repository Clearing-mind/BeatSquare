using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Left Click");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Right Click");
        }

    }
}
