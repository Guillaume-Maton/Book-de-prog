using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
