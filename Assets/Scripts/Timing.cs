using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private float secondPerBeat;
    [SerializeField] private float range;
    [SerializeField] private bool onBeat;

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Opening);
        secondPerBeat = 60.0f / bpm;
    }

    void Update()
    {
        
    }
}
