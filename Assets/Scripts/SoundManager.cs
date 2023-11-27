using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //public AudioSource bgmFixedAudioSource;
    public AudioSource bgmLoopAudioSource;
    public AudioSource seAudioSource;

    [Space(20)]
    //[SerializeField] List<BGMFixedSoundData> bgmFixedSoundDatas;
    [SerializeField] List<BGMLoopSoundData> bgmLoopSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    [Space(20)]
    //public float bgmFixedLength;
    //public float bgmFixedTime;
    public float bgmLoopLength;
    public float bgmLoopTime;

    //[Space(20)]
    //[SerializeField] private float[] samples;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //samples = new float[1024];
    }

    //public void PlayFixedBGM(BGMFixedSoundData.BGM bgm)
    //{
    //    BGMFixedSoundData data = bgmFixedSoundDatas.Find(data => data.bgm == bgm);
    //    bgmFixedAudioSource.clip = data.audioClip;
    //    bgmFixedAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
    //    bgmFixedAudioSource.Play();    
    //}

    public void PlayLoopBGM(BGMLoopSoundData.BGM bgm)
    {
        BGMLoopSoundData data = bgmLoopSoundDatas.Find(data => data.bgm == bgm);
        bgmLoopAudioSource.clip = data.audioClip;
        bgmLoopAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmLoopAudioSource.Play();
    }

    public void CheckBGMTime()
    {
        //if(bgmFixedAudioSource.clip != null)
        //{
        //    bgmFixedLength = bgmFixedAudioSource.clip.length;
        //    bgmFixedTime = bgmFixedAudioSource.time;
        //}

        if (bgmLoopAudioSource.clip != null)
        {
            bgmLoopLength = bgmLoopAudioSource.clip.length;
            bgmLoopTime = bgmLoopAudioSource.time;
        }
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

    void Update()
    {
        CheckBGMTime();

        //bgmFixedAudioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
    }

}

[System.Serializable]
public class BGMFixedSoundData
{
    public enum BGM
    {

    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}

[System.Serializable]
public class BGMLoopSoundData
{
    public enum BGM
    {
        Level1_1,
        Level1_2,
        Level1_3,
        Level1_4,
        Level1_5,
        Level1_6,
        Level1_7,
        Level1_8,
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Attack,
        Damage,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}