﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSliderScript : MonoBehaviour
{
    public Transform min, max;
    public float volumeMaster = 0.7f;
    float volume;
    float distance;
    AudioSource audio;

    void Start()
    {
        audio = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(min.position, max.position);
        volume = (distance - 0.2f) / (2.63f - 0.2f);
        volume = Mathf.Clamp(volume, 0, 1);

        if(volume < 0.05f)
        {
            volume = 0;
        }

        Mathf.Log10(volume);
        audio.volume = volume * volumeMaster;
    }
}
