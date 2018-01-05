using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Dùng Event và Delegate để các GameObject khác lắng nghe sự thay đổi Volume
public class BackgroundSoundAdjust: MonoBehaviour, IDragHandler, IPointerUpHandler {

    public delegate void OnBackgroundSoundAdjust();
    public static event OnBackgroundSoundAdjust onBackgroundSoundAdjust;
    Slider adjustVolume_Bar;

    void Start ()
    {
        adjustVolume_Bar = GetComponent<Slider>();
        // Set giá trị của thanh slider thành giá trị của BackgroundSound khi vừa load vào Setting Scene
        adjustVolume_Bar.value = SettingManager.BackgroundSound;    
    }


    public void OnPointerUp (PointerEventData ped)
    {
        SettingManager.BackgroundSound = adjustVolume_Bar.value;
        onBackgroundSoundAdjust();
    }


    public void OnDrag (PointerEventData ped)
    {
        SettingManager.BackgroundSound = adjustVolume_Bar.value;
        onBackgroundSoundAdjust();
    }


    public void Mute()
    {
        adjustVolume_Bar.value = 0;
        SettingManager.BackgroundSound = adjustVolume_Bar.value;
        onBackgroundSoundAdjust();
    }
}
