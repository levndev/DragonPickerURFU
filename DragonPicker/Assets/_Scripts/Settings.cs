using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public void MasterVolumeChanged()
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(MasterSlider.value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }
    public void SFXVolumeChanged()
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXSlider.value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
    public void MusicVolumeChanged()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicSlider.value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
            MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        if (PlayerPrefs.HasKey("SFXVolume"))
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        if (PlayerPrefs.HasKey("MusicVolume"))
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
