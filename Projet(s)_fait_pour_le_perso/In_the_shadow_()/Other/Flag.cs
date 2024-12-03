using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public string sceneName;
    private bool isPaused = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(sceneName);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
