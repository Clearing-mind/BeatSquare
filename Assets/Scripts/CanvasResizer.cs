using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResizer : MonoBehaviour
{
    public GameObject canvas;
    public Vector2 resolution;

    void Start()
    {
        resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        canvas.GetComponent<CanvasScaler>().referenceResolution = resolution;
    }

}
