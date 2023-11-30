using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartScene : MonoBehaviour
{

    public GameObject start;
    public GameObject howToPlay;
    public GameObject exit;

    public RectTransform image;
    public Vector2 screenSize;

    void Start()
    {
        start.GetComponent<Button>().onClick.AddListener(StartGame);
        exit.GetComponent<Button>().onClick.AddListener(EndGame);
        howToPlay.GetComponent<Button>().onClick.AddListener(ExplanationScene);
    }

    void Update()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        image.sizeDelta = screenSize;
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level-1");
    }

    void ExplanationScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    void EndGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
