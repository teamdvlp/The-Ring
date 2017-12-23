using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackgroundSoundAdjust: MonoBehaviour, IDragHandler, IPointerUpHandler {

    public delegate void OnBackgroundSoundAdjust();
    public static event OnBackgroundSoundAdjust onBackgroundSoundAdjust;
    Slider slider;

    void Start ()
    {
        slider = GetComponent<Slider>();
    }


    public void OnPointerUp (PointerEventData ped)
    {
        SettingManager.BackgroundSound = slider.value;
        onBackgroundSoundAdjust();
    }


    public void OnDrag (PointerEventData ped)
    {
        SettingManager.BackgroundSound = slider.value;
        onBackgroundSoundAdjust();
    }

    public void Mute()
    {
        slider.value = 0;
        SettingManager.BackgroundSound = slider.value;
        onBackgroundSoundAdjust();
    }
}
