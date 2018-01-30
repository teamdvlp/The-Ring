using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Chỉ cần add cái file Script này vào GameObject, rồi add Audio Source là nó tự động lắng nghe theo 
// Volume ở trong Setting
public class EffectSoundListener : MonoBehaviour {

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

