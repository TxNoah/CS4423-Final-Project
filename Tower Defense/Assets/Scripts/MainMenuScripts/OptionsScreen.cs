using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider, soundEffectsSlider; 

    Resolution[] resolutions;

    public AudioManager AudioManager;

    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        volumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
        soundEffectsSlider.onValueChanged.AddListener(ChangeSoundEffectsVolume);
    
    }

    public void ApplyChanges()
    {
        // Set fullscreen mode
        Screen.fullScreen = fullscreenTog.isOn;

        // Set vsync
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        // Change resolution
        SetResolution(resolutionDropdown.value);

    }

    void SetResolution(int resolutionIndex)
    {
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }

    void ChangeMasterVolume(float volume)
    {
        AudioManager.instance.SetMasterVolume(volume);
    }

    // Method to change sound effects volume
    void ChangeSoundEffectsVolume(float volume)
    {
        AudioManager.instance.SetSoundEffectsVolume(volume);
    }

}
