using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplanationScene : MonoBehaviour
{
    public GameObject back;

    void Start()
    {
        back.GetComponent<Button>().onClick.AddListener(BackToStartScene);
    }

    void BackToStartScene()
    {
        SceneManager.LoadScene("Start");
    }



}