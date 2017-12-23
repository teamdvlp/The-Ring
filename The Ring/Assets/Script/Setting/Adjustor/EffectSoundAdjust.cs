using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EffectSoundAdjust : MonoBehaviour, IDragHandler, IPointerUpHandler {
    public delegate void OnEffectSoundAdjust();
    public static event OnEffectSoundAdjust onEffectSoundAdjust;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void OnPointerUp(PointerEventData ped)
    {
        SettingManager.EffectSound = slider.value;
        onEffectSoundAdjust();
    }


    public void OnDrag(PointerEventData ped)
    {
        SettingManager.EffectSound = slider.value;
        onEffectSoundAdjust();
    }


    public void Mute ()
    {
        slider.value = 0;
        SettingManager.EffectSound = slider.value;
        onEffectSoundAdjust();
    }
}
