using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipsScene : MonoBehaviour
{
    void Start()
    {
        Invoke("StartScene", 5);
    }

    void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
}
