using UnityEngine.Audio;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	public Slider vol;

	/*static bool isPlaying = false;
	static int rand;
	private float[] time = { 322f, 274f, 276f, 232f, 270f, 266f, 437f, 462f, 233f, 279f };
	*/

	private void Start()
	{
		Play("Theme");
		/*
		while (isPlaying == false){

			StartCoroutine(RandSong());
        }
		*/
	}
		
	/*
	IEnumerator RandSong()
	{   
		rand = Random.Range(0, 9) + 1;
		Play("Track " + rand);
		
		isPlaying = true;
		yield return new WaitForSeconds(time[rand]);
		isPlaying = false;
	}
	*/

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	public void Update()
    {
		PlayerPrefs.SetFloat("volume", vol.value / 2);
		AudioListener.volume = PlayerPrefs.GetFloat("volume");
	}
}
