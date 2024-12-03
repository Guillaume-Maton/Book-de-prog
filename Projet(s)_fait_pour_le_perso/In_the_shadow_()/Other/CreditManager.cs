using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public string sceneName;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        Time.timeScale = 1f;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            LoadMainMenu();
        }
    }
}
