using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Background Music")]
    [SerializeField] private AudioClip BackgroundMusic;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip PickingSound;
    [SerializeField] private AudioClip WinningSound;
    [SerializeField] private AudioClip ButtonSound;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        if(BackgroundMusic == null)
        {
            return;
        }

        bgmSource.clip = BackgroundMusic;
        bgmSource.Play();

    }

    public void StopBackgroundMusic()
    {

        bgmSource.Stop();
    }


    public void PlayPickupSound()
    {
        if(PickingSound != null)
        {
            sfxSource.PlayOneShot(PickingSound);
        }
    }

    public void PlayWinningSound()
    {
        if(WinningSound != null)
        {
            sfxSource.PlayOneShot(WinningSound);
        }
    }

    public void PlayButtonClickSound()
    {
        if(ButtonSound != null)
        {
            sfxSource.PlayOneShot(ButtonSound);
        }
    }
}

