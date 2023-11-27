using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;
    [SerializeField] private float timeCounter;
    [SerializeField] private float bgmFixedLength;
    [SerializeField] private float bgmFixedTime;
    [SerializeField] private float bgmLoopLength;
    [SerializeField] private float bgmLoopTime;
    [SerializeField] private bool bgmLoopOn;

    [Space(20)]
    [SerializeField] private float bpm;
    [SerializeField] private float secondPerBeat;
    [SerializeField] private float beatRange;
    [SerializeField] private float beatTimer;
    [SerializeField] private float beatDelay;
    [SerializeField] public bool onBeat;

    void Start()
    {
        SoundManager.Instance.PlayLoopBGM(BGMLoopSoundData.BGM.Level1_1);

        secondPerBeat = 60.0f / bpm;
        //beatRange = 0.2f;
        beatDelay = secondPerBeat / 2.0f;
        beatTimer = beatDelay;
        bgmLoopOn = false;
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        BeatCheck();
        CheckBGMTime();

        //if (bgmFixedTime == bgmFixedLength)
        //{
        //    bgmLoopOn = true;
        //}

        //if (bgmLoopOn == true)
        //{
        //    SoundManager.Instance.PlayLoopBGM(BGMLoopSoundData.BGM.P1_Loop);
        //    bgmLoopOn = false;
        //}
        
    }

    private void BeatCheck()
    {
        beatTimer += Time.deltaTime;
        //if (beatTimer < beatRange)
        //{
        //    onBeat = true;
        //}
        if (beatTimer > secondPerBeat - beatRange)
        {
            onBeat = true;
        }
        else
        {
            onBeat = false;
        }

        if (beatTimer > secondPerBeat)
        {
            beatTimer = 0.0f;
        }
    }

    public void CheckBGMTime()
    {
        //if (soundManager.GetComponent<SoundManager>().bgmFixedAudioSource.clip != null)
        //{
        //    bgmFixedLength = soundManager.GetComponent<SoundManager>().bgmFixedAudioSource.clip.length;
        //    bgmFixedTime = soundManager.GetComponent<SoundManager>().bgmFixedAudioSource.time;
        //}

        if (soundManager.GetComponent<SoundManager>().bgmLoopAudioSource.clip != null)
        {
            bgmLoopLength = soundManager.GetComponent<SoundManager>().bgmLoopAudioSource.clip.length;
            bgmLoopTime = soundManager.GetComponent<SoundManager>().bgmLoopAudioSource.time;
        }
    }
}
