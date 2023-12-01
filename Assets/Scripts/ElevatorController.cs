﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject player;
    public GameObject endPoint;
    public float speed;
    private bool hasCollided = false;
    private int i;
    public Vector2 initialPosition;

    void Start()
    {
        initialPosition = this.transform.position;
    }

    //void Update()
    //{
    //    if (hasCollided == true)
    //    {
    //        if (Vector2.Distance(this.transform.position, points[i].position) < 0.02f)
    //        {
    //            i++;
    //            if (i == points.Length)
    //            {
    //                i = points.Length - 1;
    //            }
    //        }
    //        this.transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag== "Player"  && i != points.Length - 1)
    //    {
    //        StartCoroutine(DelayedStart(2.0f)); // 启动协程延迟两秒
    //        //collision.transform.SetParent(this.transform);
    //    }
    //}

    void Update()
    {
        if (hasCollided == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, endPoint.transform.position, speed * Time.deltaTime);
        }

        if(this.transform.position.x > endPoint.transform.position.x)
        {
            hasCollided = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DelayedStart(2.0f)); // 启动协程延迟两秒
            //collision.transform.SetParent(this.transform);
        }
    }


    private IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        hasCollided = true; // 启用移动
    }



}