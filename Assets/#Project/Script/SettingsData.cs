using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData
{

    public const string VOLUME_PREF = "volume";
    public const string INVERTED_MOUSE_PREF = "inverted mouse";


    public static int volume = 0;
    public static bool invertedMouse = false;

    public static void Load() {
        volume = PlayerPrefs.GetInt(VOLUME_PREF,0);
        invertedMouse = PlayerPrefs.GetInt(INVERTED_MOUSE_PREF, 0) > 0;
    }
    public static void BumpVolume() {
        volume++;
        PlayerPrefs.SetInt(VOLUME_PREF, volume);
    }

    public static void SwitchInvertedMouse(bool newSetting) {
        invertedMouse = newSetting;
        PlayerPrefs.SetInt(INVERTED_MOUSE_PREF, invertedMouse?1:0);
    }
}
