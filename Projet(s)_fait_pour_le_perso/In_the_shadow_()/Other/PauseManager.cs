using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Référence à l'UI du menu Pause.
    public GameObject pauseUI;

    // appel la scene dont le nom est donné.
    public string sceneName;

    // Update qui ne se fera qu'au moment où la touche échap est appuyer.
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
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

    // commande permettant de fermer l'ui de la pause.
    public void ClosePause()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    // commande permettant d'ouvrir l'ui de la pause.
    public void OpenPause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenMenu(GameObject open)
    {
        open.SetActive(true);
    }

    public void CloseMenu(GameObject close) 
    {
        close.SetActive(false);
    }

    // commande permettant d'appeler la scene demander.
    public void HomeButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}