using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    double pauseClipTime = 0;
    public AudioClip[] clips;
    int currentClipIndex = 0;

    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.clip = clips[0];
        musicAudioSource.Play();
    }
    private void Update()
    {
        if (musicAudioSource.time >= clips[currentClipIndex].length)
        {
            currentClipIndex++;
            if (currentClipIndex >= clips.Length)
            {
                currentClipIndex = 0;
            }
            musicAudioSource.clip = clips[currentClipIndex];
            musicAudioSource.Play();
        }
    }
    public void OnGamePause()
    {
        pauseClipTime = musicAudioSource.time;
        musicAudioSource.Pause();
    }
    public void OnGameResume()
    {
        musicAudioSource.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
    }

    public void SetPich(float value)
    {
        musicAudioSource.pitch = value;
    }
}
