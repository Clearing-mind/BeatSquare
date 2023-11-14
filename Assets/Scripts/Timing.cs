using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Opening);
    }

    void Update()
    {
        
    }
}
