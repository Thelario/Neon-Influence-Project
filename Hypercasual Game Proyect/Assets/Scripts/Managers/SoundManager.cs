using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance { get; private set; }
	
	public AudioSource[] audioSources; // 0.BGM , 1.SFX

	public AudioClip backgroundMusic;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		PlayBGM(backgroundMusic);
	}

	public void PlayBGM(AudioClip clip)
	{
		audioSources[0].clip = clip;
		audioSources[0].Play();
	}

	public void PlaySFX(AudioClip clip)
	{
		audioSources[1].PlayOneShot(clip);
	}
}
