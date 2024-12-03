using System.Collections;
using TMPro;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PotionCount pC;

    public TextMeshProUGUI potionText;
    public GameObject potionCase;

    public AudioSource takePotionSource;
    public AudioSource potionSource;

    public void Update()
    {
        potionText.text = "" + pC.potionCount;
        potionText.color = Color.white;

        if (pC.potionCount == 0)
        {
            potionCase.SetActive(false);
        }
        else if (pC.potionCount > 0)
        {
            potionCase.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.H) && playerHealth.currentHealth < 20)
            {
                potionSource.Play();
                playerHealth.TakeHealth(3);
                pC.potionCount--;
            }

            if (Input.GetKeyDown(KeyCode.H) && playerHealth.currentHealth == 20)
            {
                playerHealth.TakeHealth(0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Health Potion"))
        {
            StartCoroutine(Potion());
        }

        IEnumerator Potion()
        {
            takePotionSource.Play();
            pC.potionCount++;
            Destroy(collision.gameObject);
            yield return null;
        }
    }
}