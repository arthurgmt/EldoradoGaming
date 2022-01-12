using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;

    public Slider cameraSpeedSlider;

    public float speed;
    public float volume;
    public string resolution;

    public void Start()
    {
        GameConf c = DataSaver.loadData<GameConf>("gameConf");
        if (c != null)
        {
            musicSlider.value = c.musicSound;
            cameraSpeedSlider.value = c.speedCamera;
        }
        else
        {
            musicSlider.value = 50;
            cameraSpeedSlider.value = 50;
        }
    }
    public void SetVolume()
    {
        this.volume = musicSlider.value;
        audioMixer.SetFloat("Music", volume);
    }

    public void SetRotation()
    {
        this.speed = this.cameraSpeedSlider.value;
    }

}
