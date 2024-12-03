using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cardinal : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public GameObject pauseUI;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSfxVolume();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseUI.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }

    private void OpenPause()
    {
        // Affichez le menu settings
        pauseUI.SetActive(true);

        // Met le jeu en pause
        Time.timeScale = 0f;
    }

    private void ClosePause()
    {
        // Cachez le menu settings
        pauseUI.SetActive(false);

        // Remet le jeu en route
        Time.timeScale = 1f;
    }

    public void OpenMenu(GameObject open)
    {
        open.SetActive(true);
    }

    public void CloseMenu(GameObject close)
    {
        close.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSfxVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSfxVolume();
    }
}