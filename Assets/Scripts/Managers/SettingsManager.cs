using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsManager : MonoSingleton<SettingsManager>
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private TMP_Dropdown _resoultionDropdown;

    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

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

        float masterVol = PlayerPrefs.GetFloat("masterVolume");
        float musicVol = PlayerPrefs.GetFloat("bgmVolume");
        float sfxVol = PlayerPrefs.GetFloat("sfxVolume");

        if (PlayerPrefs.HasKey("masterVolume"))
        {
            SetMasterVolume(masterVol);
            _masterSlider.value = masterVol;
        }
        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            SetMusicVolume(musicVol);
            _musicSlider.value = musicVol;
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            SetSFXVolume(sfxVol);
            _sfxSlider.value = sfxVol;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume(float volume)
    {
        _mixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        _mixer.SetFloat("bgmVolume", volume);
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        _mixer.SetFloat("sfxVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
