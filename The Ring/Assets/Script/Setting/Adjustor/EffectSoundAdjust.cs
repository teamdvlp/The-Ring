using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Dùng Event và Delegate để các GameObject khác lắng nghe sự thay đổi Volume
public class EffectSoundAdjust : MonoBehaviour, IDragHandler, IPointerUpHandler {
    public delegate void OnEffectSoundAdjust();
    public static event OnEffectSoundAdjust onEffectSoundAdjust;
    Slider adjustVolume_Bar;


    void Start()
    {
        adjustVolume_Bar = GetComponent<Slider>();
        // Set giá trị của thanh slider thành giá trị của EffectSound khi vừa load vào Setting Scene
        adjustVolume_Bar.value = SettingManager.EffectSound;
    }


    public void OnPointerUp(PointerEventData ped)
    {
        SettingManager.EffectSound = adjustVolume_Bar.value;
        onEffectSoundAdjust();
    }


    public void OnDrag(PointerEventData ped)
    {
        SettingManager.EffectSound = adjustVolume_Bar.value;
        onEffectSoundAdjust();
    }


    public void Mute ()
    {
        adjustVolume_Bar.value = 0;
        SettingManager.EffectSound = adjustVolume_Bar.value;
        onEffectSoundAdjust();
    }
}
