using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioClip[] _bgmClips;
    [SerializeField] private AudioClip _pauseClip;

    private AudioClip _oldClip;

    private AudioSource _audio;
    private AudioSource _bgmAudio;

    void OnEnable()
    {
        PlayerController.onPauseGame += PlayPauseMusic;
        PlayerController.onResumeGame += ResumeLastClip;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _bgmAudio = transform.GetChild(0).GetComponent<AudioSource>();
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

    public void PlayMusic(int clip)
    {
        _bgmAudio.Stop();
        _bgmAudio.clip = _bgmClips[clip];
        _bgmAudio.Play();

        if (clip == 3)
        {
            _bgmAudio.loop = false;
        }
    }

    public void PlayPauseMusic()
    {
        _oldClip = _bgmAudio.clip;

        _bgmAudio.Stop();
        _bgmAudio.clip = _pauseClip;
        _bgmAudio.Play();
    }

    public void ResumeLastClip()
    {
        _bgmAudio.Stop();

        _bgmAudio.clip = _oldClip;
        _bgmAudio.Play();
    }

    void OnDisable()
    {
        PlayerController.onPauseGame -= PlayPauseMusic;
        PlayerController.onResumeGame -= ResumeLastClip;
    }
}
