using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoMovement : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;

    public GameObject tempo_1;

    //public float speed = 5.0f;
    public float distance;

    public Vector2 startPointPosition;
    public Vector2 endPointPosition;

    void Start()
    {
        startPointPosition = startPoint.transform.localPosition;
        endPointPosition = endPoint.transform.localPosition;
        distance = Vector2.Distance(startPoint.transform.position, endPoint.transform.position);
    }


    void Update()
    {
        TempoMover(tempo_1);
    }

    void TempoMover(GameObject tempo)
    {
        //tempo.transform.Translate(Vector3.right * speed * Time.deltaTime);

        tempo.transform.position = new Vector2(startPoint.transform.position.x, this.transform.position.y);

        if (tempo.transform.localPosition.x > endPointPosition.x)
        {
            tempo.transform.localPosition = startPointPosition;
        }
    }

}
