using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    public GameObject start;
    public GameObject howToPlay;
    public GameObject exit;

    void Start()
    {
        start.GetComponent<Button>().onClick.AddListener(StartGame);
        exit.GetComponent<Button>().onClick.AddListener(EndGame);
        howToPlay.GetComponent<Button>().onClick.AddListener(ExplanationScene);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Scene1"); 
    }

    void ExplanationScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
