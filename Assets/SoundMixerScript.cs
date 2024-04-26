using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", level);
    }

    void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFxVolume", level);
    }

    void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", level);
    }
}
