using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackgroundSound : MonoBehaviour {

    AudioSource audioSourcee;


    public void OnSoundAdjust ()
    {
        SetVolume();
    }

    void Start ()
    {
        audioSourcee = GetComponent<AudioSource>();
        SetVolume();
        BackgroundSoundAdjust.onBackgroundSoundAdjust += OnSoundAdjust;
    }

    private void SetVolume()
    {
		if (audioSourcee == null) return;

        audioSourcee.volume = SettingManager.BackgroundSound;
        
    }
}
