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
    public AudioClip screen_clap;
    public AudioClip sand;
    public AudioClip boot_up;
    public AudioClip pre_boot;

    AudioSource[] audioSources;

    AudioSource lastFuseSource;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void playSound(ref AudioClip sound, float volume = 1, bool randomPitch = false)
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.clip = sound;

        if(randomPitch)
        {
            source.pitch = Random.Range(0.9f, 1.1f);
        }

        source.volume = volume;
        source.Play();
    }

    public void playClick()
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.clip = click;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.volume = 1;
        source.Play();
    }

    public void playIntro()
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.clip = intro;
        source.volume = 1;
        source.Play();
    }

    public void playOutro()
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.clip = outro;
        source.volume = 1;
        source.Play();
    }

    public void playFuse()
    {
        AudioSource source = GetAvailableAudioSource();
        lastFuseSource = source;
        source.loop = false;
        source.clip = fuse;
        source.volume = 1;
        source.Play();
    }

    public void stopFuse()
    {
        lastFuseSource.Stop();
    }

    public void playExplosion()
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.clip = explosion;
        source.volume = 1;
        source.Play();
    }

    public void PlayButtonClick(bool activation)
    {
        AudioSource source = GetAvailableAudioSource();
        source.loop = false;
        source.clip = (activation) ? button_ok : button_denied;
        source.pitch = Random.Range(0.9f, 2.1f);
        source.volume = 1;
        source.Play();
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach(AudioSource source in audioSources)
        {
            if(!source.isPlaying && source != audioSources[0])
            {
                return source;
            }
        }
        return audioSources[0];
    }


}
