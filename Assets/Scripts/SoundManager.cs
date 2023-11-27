using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource[] bgmAudioSources;
    public AudioSource seAudioSource;

    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    [Space(20)]
    public float bgmLength;
    public float bgmTime;

    //[Space(20)]
    //[SerializeField] private float[] samples;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //samples = new float[1024];
    }

    public void PlayBGM(int bgmIndex, float volume)
    {
        if (bgmIndex < 0 || bgmIndex >= bgmAudioSources.Length)
        {
            Debug.LogError("BGM index out of range");
            return;
        }

        AudioSource source = bgmAudioSources[bgmIndex];
        source.clip = bgmAudioSources[bgmIndex].clip;
        source.volume = volume * bgmMasterVolume * masterVolume;
        source.Play();
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

    public void AdjustBGMVolume(int bgmIndex, float volume)
    {
        if (bgmIndex < 0 || bgmIndex >= bgmAudioSources.Length)
        {
            Debug.LogError("BGM index out of range");
            return;
        }

        AudioSource source = bgmAudioSources[bgmIndex];
        source.volume = volume * bgmMasterVolume * masterVolume;
    }

    void Update()
    {
        CheckBGMTime();
        //bgmFixedAudioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
    }

    public void CheckBGMTime()
    {
        if (bgmAudioSources[0].clip != null)
        {
            bgmLength = bgmAudioSources[0].clip.length;
            bgmTime = bgmAudioSources[0].time;
        }
    }
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Attack,
        Jump_Full,
        Jump_Half,
        Damage,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}