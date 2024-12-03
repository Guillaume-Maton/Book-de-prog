using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgmSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBgmVolume();
        }
    }

    public void SetBgmVolume()
    {
        float volume = bgmSlider.value;
        audioMixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }

    private void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");

        SetBgmVolume();
    }
}