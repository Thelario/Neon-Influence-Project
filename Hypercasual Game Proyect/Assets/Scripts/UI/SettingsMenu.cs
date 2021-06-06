using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	/* BACKGROUND VOLUME */
	public void SetBackgroundVolumen(float volume)
	{
		audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
	}

	/* SOUND EFFECTS VOLUME */
	public void SetSoundEffectsVolumen(float volume)
	{
		audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
	}

	public void GetVolumes()
	{
		audioMixer.GetFloat("BGMVolume", out DoNotDestroy.previousBackgroundVolume);
		audioMixer.GetFloat("SFXVolume", out DoNotDestroy.previousSoundEffectsVolume);
	}
}
