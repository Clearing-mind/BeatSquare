using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] bgmPositions = new GameObject[6];

    [Space(20)]
    [SerializeField] private float timeCounter;
    [SerializeField] private float bgmLength;
    [SerializeField] private float bgmTime;

    [Space(20)]
    [SerializeField] private float bpm;
    [SerializeField] private float secondPerBeat;
    [SerializeField] private float beatRange;
    [SerializeField] private float beatTimer;
    [SerializeField] private float beatDelay;
    [SerializeField] public bool onBeat;

    [Space(20)]
    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject tempo_1;
    public float distance;
    public Vector2 startPointPosition;
    public Vector2 endPointPosition;

    void Start()
    {

        secondPerBeat = 60.0f / bpm;
        //beatRange = 0.2f;
        //beatDelay = secondPerBeat / 2.0f;
        beatTimer = beatDelay;

        startPointPosition = startPoint.transform.localPosition;
        endPointPosition = endPoint.transform.localPosition;
        distance = Vector2.Distance(startPoint.transform.position, endPoint.transform.position);

        SoundManager.Instance.PlayBGM(0, 1.0f);
        SoundManager.Instance.PlayBGM(1, 0.0f);
        SoundManager.Instance.PlayBGM(2, 0.0f);
        SoundManager.Instance.PlayBGM(3, 0.0f);
        SoundManager.Instance.PlayBGM(4, 0.0f);
        SoundManager.Instance.PlayBGM(5, 0.0f);
        SoundManager.Instance.PlayBGM(6, 0.0f);
        //SoundManager.Instance.PlayBGM(7, 0.0f);
    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        //for (int i = 1; i <= 6; i++)
        //{
        //    if (timeCounter >= 2.0f * i)
        //    {
        //        SoundManager.Instance.AdjustBGMVolume(i, 1.0f);
        //    }
        //}

        for (int i = 0; i < bgmPositions.Length; i++)
        {
            if (player.transform.position.x >= bgmPositions[i].transform.position.x)
            {
                SoundManager.Instance.AdjustBGMVolume(i + 1, 1.0f);
            }
        }

        CheckBGMTime();
        BeatCheck();
        TempoMover(tempo_1);
    }

    private void BeatCheck()
    {
        beatTimer += Time.deltaTime;

        //if (bgmTime <= 1.0f / bpm)
        //{
        //    beatTimer = 0.0f;
        //    //print("����");
        //}

        if ((beatTimer > secondPerBeat - beatRange) || (beatTimer < beatRange/2.0f))
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
        if (soundManager.GetComponent<SoundManager>().bgmAudioSources[0].clip != null)
        {
            bgmLength = soundManager.GetComponent<SoundManager>().bgmAudioSources[0].clip.length;
            bgmTime = soundManager.GetComponent<SoundManager>().bgmAudioSources[0].time;
        }
    }

    void TempoMover(GameObject tempo)
    {
        //tempo.transform.Translate(Vector3.right * speed * Time.deltaTime);

        tempo.transform.position = new Vector2(startPoint.transform.position.x + beatTimer * distance, startPoint.transform.position.y);

        if (tempo.transform.localPosition.x > endPointPosition.x)
        {
            tempo.transform.localPosition = startPointPosition;
        }
    }
}
