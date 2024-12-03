using TMPro;
using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour
{
    public Key KC;
    public TextMeshProUGUI keyText;
    public GameObject keyCase;
    public bool isKey;

    public AudioSource keySource;

    public void Update()
    {
        keyText.text = "" + KC.keyCount;
        keyText.color = Color.white;

        if (KC.keyCount == 0)
        {
            keyCase.SetActive(false);
            isKey = false;
        }

        else if (KC.keyCount > 0)
        {
            keyCase.SetActive(true);
            isKey = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Key"))
        {
            StartCoroutine(Key());
        }

        IEnumerator Key()
        {
            keySource.Play();
            keyCase.SetActive(true);
            KC.keyCount++;
            Destroy(collision.gameObject);
            yield return null;
        }
    }
}