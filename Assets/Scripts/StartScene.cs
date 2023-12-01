using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartScene : MonoBehaviour
{

    public GameObject start;
    public GameObject controls;
    public GameObject credits;
    public GameObject exit;

    public RectTransform image;
    public Vector2 screenSize;

    void Start()
    {
        start.GetComponent<Button>().onClick.AddListener(StartGame);
        controls.GetComponent<Button>().onClick.AddListener(ControlsScene);
        credits.GetComponent<Button>().onClick.AddListener(CreditsScene);
        exit.GetComponent<Button>().onClick.AddListener(EndGame);
    }

    void Update()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        //image.sizeDelta = screenSize;
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level-1");
    }

    void ControlsScene()
    {
        SceneManager.LoadScene("Controls");
    }

    void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    void EndGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
