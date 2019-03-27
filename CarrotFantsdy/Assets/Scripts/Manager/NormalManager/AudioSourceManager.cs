using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 负责控制音乐的播放和停止以及各种音效的控制
/// </summary>
public class AudioSourceManager
{
	/// <summary>
	/// 0播放bg，1播放特效音乐
	/// </summary>
	private AudioSource[] audioSource;

	private bool playEffectMusic = true;
	private bool playBGMusic = true;

	public AudioSourceManager()
	{
		audioSource = GameManager.Instance.GetComponents<AudioSource>();
		
	}

	public void PlayBGMusic(AudioClip audioClip)
	{
		if (!audioSource[0].isPlaying||audioSource[0].clip != audioClip)
		{
			audioSource[0].clip = audioClip;
			audioSource[0].Play();
		}
	}

	public void PlayEffectMusic(AudioClip audioClip)
	{
		if (playEffectMusic)
		{
			audioSource[1].PlayOneShot(audioClip);
		}
	}

	public void CloseBGMusic()
	{
		audioSource[0].Stop();
	}

	public void OpenBgMusic()
	{
		audioSource[0].Play();
	}

	public void CloseOrOpenBGMusic()
	{
		playBGMusic = !playBGMusic;
		if (playBGMusic)
		{
			OpenBgMusic();
		}
		else
		{
			CloseBGMusic();
		}
	}

	public void CloseOrOpenEffectMusic()
	{
		playEffectMusic = !playEffectMusic;
	}
}
