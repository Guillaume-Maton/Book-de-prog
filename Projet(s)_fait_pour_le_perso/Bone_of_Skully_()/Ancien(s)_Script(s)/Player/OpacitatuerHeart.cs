using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpacitatuerHeart : MonoBehaviour
{
    public Image graphics;
    public Image heartCase;
    public TextMeshProUGUI heartText;

    private void Update()
    {
        if (PlayerHealth.instance.currentHealth == 20)
        {
            graphics.color = new Color(1f, 1f, 1f, 1f);
            heartCase.color = new Color(1f, 1f, 1f, 1f);
            heartText.color = new Color(1f, 1f, 1f, 1f);
        }

        if (PlayerHealth.instance.currentHealth <= 18)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.9f);
        }

        if (PlayerHealth.instance.currentHealth <= 16)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.8f);
        }

        if (PlayerHealth.instance.currentHealth <= 14)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.7f);
        }

        if (PlayerHealth.instance.currentHealth <= 12)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.6f);
        }

        if (PlayerHealth.instance.currentHealth <= 10)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (PlayerHealth.instance.currentHealth <= 8)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.4f);
        }

        if (PlayerHealth.instance.currentHealth <= 6)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.3f);
        }

        if (PlayerHealth.instance.currentHealth <= 4)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.2f);
        }

        if (PlayerHealth.instance.currentHealth <= 2)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.1f);
        }

        if (PlayerHealth.instance.currentHealth == 0)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            heartCase.color = new Color(1f, 1f, 1f, 0f);
            heartText.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
