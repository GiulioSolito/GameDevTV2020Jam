using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
	[SerializeField] private AudioClip[] _bgmClips;
		
	private AudioSource _audio;

	// Use this for initialization
	void Awake()
	{
		_audio = GetComponent<AudioSource>();

		if (!_audio.playOnAwake)
		{
			if (_audio.clip != null)
			{
				_audio.clip = _bgmClips[Random.Range(0, _bgmClips.Length)];
				_audio.Play();
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!_audio.isPlaying)
		{
			if (_audio.clip != null)
			{
				_audio.clip = _bgmClips[Random.Range(0, _bgmClips.Length)];
				_audio.Play();
			}
		}
	}
}
