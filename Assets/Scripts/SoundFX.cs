using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioClip click;
    public AudioClip intro;
    public AudioClip outro;
    public AudioClip fuse;
    public AudioClip explosion;
    public AudioClip button_ok;
    public AudioClip button_denied;

    AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void playClick()
    {
        audioSources[0].loop = false;
        audioSources[0].clip = click;
        audioSources[0].pitch = Random.Range(0.9f, 1.1f);
        audioSources[0].volume = 1;
        audioSources[0].Play();
    }

    public void playIntro()
    {
        audioSources[1].loop = false;
        audioSources[1].clip = intro;
        audioSources[1].volume = 1;
        audioSources[1].Play();
    }

    public void playOutro()
    {
        audioSources[1].loop = false;
        audioSources[1].clip = outro;
        audioSources[1].volume = 1;
        audioSources[1].Play();
    }

    public void playFuse()
    {
        audioSources[2].loop = false;
        audioSources[2].clip = fuse;
        audioSources[2].volume = 1;
        audioSources[2].Play();
    }

    public void stopFuse()
    {
        audioSources[2].Stop();
    }

    public void playExplosion()
    {
        audioSources[3].loop = false;
        audioSources[3].pitch = Random.Range(0.9f, 1.1f);
        audioSources[3].clip = explosion;
        audioSources[3].volume = 1;
        audioSources[3].Play();
    }

    public void PlayButtonClick(bool activation)
    {
        audioSources[0].loop = false;
        audioSources[0].clip = (activation) ? button_ok : button_denied;
        audioSources[0].pitch = Random.Range(0.9f, 2.1f);
        audioSources[0].volume = 1;
        audioSources[0].Play();
    }


}
