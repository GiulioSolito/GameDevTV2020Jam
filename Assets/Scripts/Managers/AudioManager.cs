using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoSingleton<AudioManager>
{
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        _audio.clip = clip;
        _audio.Play();
    }

    public void StopSound()
    {
        _audio.Stop();
    }

    public void PlayFootstepSound(AudioClip[] footsteps, int clipToPlay)
    {
        _audio.clip = footsteps[clipToPlay];
        _audio.Play();
    }
}
