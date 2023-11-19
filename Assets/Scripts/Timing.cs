using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private float secondPerBeat;
    [SerializeField] private float range;
    [SerializeField] private float timer;
    [SerializeField] private bool onBeat;

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Opening);
        secondPerBeat = 60.0f / bpm;
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < range)
        {
            onBeat = true;
        }
        else if (timer > secondPerBeat - range)
        {
            onBeat = true;
        }
        else
        {
            onBeat = false;
        }

        if (timer > secondPerBeat)
        {
            timer = 0.0f;
        }
    }
}
