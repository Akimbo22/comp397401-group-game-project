using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("music");
        musicSource.volume = musicVolume;
        musicSlider.value = musicVolume;

        sfxVolume = PlayerPrefs.GetFloat("sfx");
        sfxSource.volume = sfxVolume;
        sfxSlider.value = sfxVolume;
        
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.volume = musicVolume;
        PlayerPrefs.SetFloat("music", musicVolume);

        sfxSource.volume = sfxVolume;
        PlayerPrefs.SetFloat("sfx", sfxVolume);
        
    }

    public void updateMusicVolume(float volume)
    {
        musicVolume = volume;
    }
    public void updateSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
}
