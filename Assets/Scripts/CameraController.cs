using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public Vector3 offset;

    [Space(20)]
    public float zoom;
    public float zoomMultiplier = 4f;
    public float minZoom = 2f;
    public float maxZoom = 8f;
    public float velocity = 0f;
    public float smoothTime = 0.25f;

    private void Start()
    {
        zoom = cam.orthographicSize;
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + offset, 6.0f * Time.deltaTime);  
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }
}
