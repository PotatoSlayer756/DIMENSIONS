using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]private AudioSource soundObject;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void PlaySoundClip(AudioClip clip, Transform spawntransform, float volume)
    {
        AudioSource audiosource = Instantiate(soundObject, spawntransform.position, Quaternion.identity);
        audiosource.clip = clip;
        audiosource.volume = volume;
        audiosource.Play();
        float clipLength = audiosource.clip.length;
        Destroy(audiosource.gameObject, clipLength);
    }

    public void PlayRandomSoundClip(AudioClip[] clip, Transform spawntransform, float volume)
    {
        int rand = UnityEngine.Random.Range(0, clip.Length);

        AudioSource audiosource = Instantiate(soundObject, spawntransform.position, Quaternion.identity);
        audiosource.clip = clip[rand];
        audiosource.volume = volume;
        audiosource.Play();
        float clipLength = audiosource.clip.length;
        Destroy(audiosource.gameObject, clipLength);
    }


    public void PlaySoundClipsUntilActive(AudioClip[] clip, Transform spawnTransform)
    {
        AudioSource audioSource = Instantiate(soundObject, spawnTransform.position, Quaternion.identity);

        while (spawnTransform.gameObject.activeSelf)
        {
            int rand = UnityEngine.Random.Range(0, clip.Length);
            audioSource.clip = clip[rand];
            audioSource.Play();

            // Start a coroutine to wait until the audio is finished playing
            StartCoroutine(WaitForAudioToFinish(audioSource));
        }

        Destroy(audioSource.gameObject);
    }

    private IEnumerator WaitForAudioToFinish(AudioSource audioSource)
    {
        while (audioSource.isPlaying) { yield return null; }
    }


    /*public void PlaySoundClipUntilCondition(AudioClip[] clip, Transform spawntransform, float volume, Func<bool> condition)
    {
        int rand = UnityEngine.Random.Range(0, clip.Length);

        AudioSource audiosource = Instantiate(soundObject, spawntransform.position, Quaternion.identity);
        audiosource.clip = clip[rand];
        audiosource.volume = volume;
        audiosource.Play();

        StartCoroutine(PlaySoundUntilCondition(audiosource, condition));
    }

    private IEnumerator PlaySoundUntilCondition(AudioSource audioSource, Func<bool> condition)
    {
        while (!condition())
        {
            yield return null;
        }
        audioSource.Stop();
        Destroy(audioSource.gameObject);
    }*/
}
