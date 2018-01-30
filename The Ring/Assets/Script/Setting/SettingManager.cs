using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Language
{
    Vietnamese,
    English,
    China
}

public enum SoundType
{
    EffectSound,
    BackgroundSound,
    VoiceSound
}


public class SettingManager : MonoBehaviour{
    public static float EffectSound = 1;
    public static float BackgroundSound = 1;
    public static float VoiceSound = 1;
    public static Language language;
}
