using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameConf
{
    public float speedCamera;
    public float musicSound;
    public string resolution;

    public GameConf(float speedCamera, float musicSound, string resolution)
    {
        this.speedCamera = speedCamera;
        this.musicSound = musicSound;
        this.resolution = resolution;
    }
}
