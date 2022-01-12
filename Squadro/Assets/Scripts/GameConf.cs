using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameConf
{
    public float speedCamera;
    public float musicSound;

    public GameConf(float speedCamera, float musicSound)
    {
        this.speedCamera = speedCamera;
        this.musicSound = musicSound;
    }
}
