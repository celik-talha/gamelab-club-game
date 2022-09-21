using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private int _musicOn;
    private int _sfxOn;
    
    private AudioSource _audioSource;
    private AudioSource _sfxSource;
    [SerializeField] private GameObject sfxObject;
    
    [SerializeField] private AudioClip[] musics;
    
    private AudioClip currrent;
    
    private int i;

    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip phoneClip;
    [SerializeField] private AudioClip hitClip;
    void Awake()
    {
        _sfxSource = sfxObject.GetComponent<AudioSource>();   
        _audioSource = this.GetComponent<AudioSource>();
        i = Random.Range(0, 3);
        _audioSource.clip = musics[i];
        
        _musicOn = PlayerPrefs.GetInt("music", 1);
        _sfxOn = PlayerPrefs.GetInt("sfx", 1);

        _audioSource.Play();
        if (_musicOn == 0)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.UnPause();
        }
    }

    public void StopMusic()
    {
        _audioSource.Pause();
        PlayerPrefs.SetInt("music",0);
        _musicOn = 0;
    }

    public void PlayMusic()
    {
        _audioSource.UnPause();
        PlayerPrefs.SetInt("music",1);
        _musicOn = 1;
    }
    
    public void StopSfx()
    {
        PlayerPrefs.SetInt("sfx",0);
        _sfxOn = 0;
    }

    public void PlaySfx()
    {
        PlayerPrefs.SetInt("sfx",1);
        _sfxOn = 1;
    }

    public void hitSound()
    {
        if (_sfxOn == 1)
        {
            _sfxSource.clip = hitClip;
            _sfxSource.Play();
        }
    }

    public void phoneSound()
    {
        if (_sfxOn == 1)
        {
            _sfxSource.clip = phoneClip;
            _sfxSource.Play();
        }
    }

    public void buttonSound()
    {
        if (_sfxOn == 1)
        {
            _sfxSource.clip = buttonClip;
            _sfxSource.Play();
        }
    }
}