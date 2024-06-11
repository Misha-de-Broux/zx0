using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] TMP_Text volumeText;
    [SerializeField] Toggle invertedMouseToggle;
    private void Start() {
        SettingsData.Load();
        volumeText.text = $"Volume: {SettingsData.volume}";
        invertedMouseToggle.isOn = SettingsData.invertedMouse;
    }

    public void BumpVolume() {
        SettingsData.BumpVolume();
        volumeText.text = $"Volume: {SettingsData.volume}";
    }

    public void SwitchInvertedMouse(bool value) {
        SettingsData.SwitchInvertedMouse(value);
    }
}
