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
        musicSlider.value = c.musicSound;
        cameraSpeedSlider.value = c.speedCamera;
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
