using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Setting : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _resolutionDropdown;
    private Resolution[] _resolutions;
    [SerializeField] private AudioMixer _myMixer;
    [SerializeField] private UnityEngine.UI.Slider _audioMusic;
    [SerializeField] private UnityEngine.UI.Slider _audioSound;
    [SerializeField] private UnityEngine.UI.Slider _audioMaster;

    public void Start()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
        
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume()
    {
        float volume = _audioMusic.value;
        _myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _audioSound.value;
        _myMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMasterVolume()
    {
        float volume = _audioMaster.value;
        _myMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void LoadVolume()
    {
        _audioMusic.value = PlayerPrefs.GetFloat("musicVolume");
        _audioSound.value = PlayerPrefs.GetFloat("soundVolume");
        _audioMaster.value = PlayerPrefs.GetFloat("MasterVolume");

        SetMusicVolume();
    }

}
