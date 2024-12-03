 using System.Collections;
using UnityEngine;
using TMPro;

public class CompteurRuby : MonoBehaviour
{
    public Ruby br;
    public TextMeshProUGUI rubyText;

    public GameObject rubyCase;
    public AudioSource rubySource;

    public void Update()
    {
        rubyText.text = "" + br.rubyCount;
        rubyText.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ruby"))
        {
            StartCoroutine(Ruby());
        }

        IEnumerator Ruby()
        {
            rubySource.Play();
            br.rubyCount++;
            yield return new WaitForSeconds(0.002f);
            Destroy(other.gameObject);
        }
    }
}