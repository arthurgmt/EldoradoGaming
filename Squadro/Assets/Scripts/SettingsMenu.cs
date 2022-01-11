﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public AudioMixer audioMixer;
    
    public Slider musicSlider;

    public Slider cameraSpeedSlider;

    public float speed;
    public float volume;
    public string resolution;

    public void Start()
    {
        GameConf c = DataSaver.loadData<GameConf>("gameConf");
        //audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = c.musicSound;
        cameraSpeedSlider.value = c.speedCamera;

        // On récupère toutes les résolutions puis on fait un distinct pour ne pas les avoirs en doubles 
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
       
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }
    public void SetVolume(float volume)
    {
        this.volume = volume;
        audioMixer.SetFloat("Music", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolIndex)
    {
        Resolution resolution = resolutions[resolIndex];
        this.resolution = resolution.width + "x" + resolution.height;
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetRotation()
    {
        this.speed = this.cameraSpeedSlider.value;
    }

}
