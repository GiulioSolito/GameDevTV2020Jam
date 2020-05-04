using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Linq;
public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private TMP_Dropdown _resoultionDropdown;

    private List<Resolution> _resolutions;

    void Start()
    {
        _resoultionDropdown.ClearOptions();

        _resolutions = new List<Resolution>();
        _resolutions.AddRange(Screen.resolutions.Where(resolution => resolution.refreshRate == 60));

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < _resolutions.Count; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        _resoultionDropdown.AddOptions(options);
        _resoultionDropdown.value = currentResolutionIndex;
        _resoultionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume(float volume)
    {
        _mixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        _mixer.SetFloat("bgmVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        _mixer.SetFloat("sfxVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
