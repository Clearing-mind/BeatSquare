using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipsScene : MonoBehaviour
{
    void Start()
    {
        Invoke("StartScene", 3.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }

    void StartScene()
    {
        SceneManager.LoadScene("Start");
    }

    void EndGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
