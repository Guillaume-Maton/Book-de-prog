using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClick_Sound()
    {
        menuManager.OpenMenu(Menu.SOUND, gameObject);
    }

    public void OnClick_Quit()
    {
        menuManager.OpenMenu(Menu.QUIT, gameObject);
    }
}