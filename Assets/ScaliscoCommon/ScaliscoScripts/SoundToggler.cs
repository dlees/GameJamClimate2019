using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggler : MonoBehaviour
{
    private const string IS_SOUND_ON_PREF = "isSoundOn";
    private const string VOLUME_PREF = "VOLUME_PREF";
    public Toggle toggle;

    public bool isSoundOn() { return PlayerPrefs.GetInt(IS_SOUND_ON_PREF) != 0; }
    public float getVolume() { return PlayerPrefs.GetFloat(VOLUME_PREF); }

    void Awake() {
        if (!PlayerPrefs.HasKey(IS_SOUND_ON_PREF)) {
            PlayerPrefs.SetInt(IS_SOUND_ON_PREF, 1);
        }
        /*
        if (!PlayerPrefs.HasKey(VOLUME_PREF)) {
            PlayerPrefs.GetFloat(VOLUME_PREF, 1);
        }
        */

        setVolumeBasedOnFlag(isSoundOn());
        if (toggle != null) {
            toggle.isOn = isSoundOn();
        }
    }

    private void setVolumeBasedOnFlag(Boolean shouldSoundBeOn) {
        AudioListener.volume = shouldSoundBeOn ? 1f : 0f;
    }

    public void setIsSoundActive(Boolean isSoundActive) {
        setVolumeBasedOnFlag(isSoundActive);
        PlayerPrefs.SetInt(IS_SOUND_ON_PREF, isSoundActive ? 1 : 0);
    }
}
