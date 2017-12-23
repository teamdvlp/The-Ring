using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour {

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetVolume();
        EffectSoundAdjust.onEffectSoundAdjust += OnSoundAdjust;
    }

    private void SetVolume()
    {
        if (audioSource == null)
        {
            Debug.Log("AUDIO EFFECT ERROR");
        }
        else
        {
            audioSource.volume = SettingManager.EffectSound;
        }
    }

    public void OnSoundAdjust()
    {
        SetVolume();
    }
}

