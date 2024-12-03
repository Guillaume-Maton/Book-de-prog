using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    private bool isInvincible = false;

    public SpriteRenderer graphics;
    public TextMeshProUGUI hpText;
    public GameObject gameOverUI;

    public AudioSource overSource;
    public AudioSource criticalHeartSource;

    public bool isPaused = false;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void Update()
    {
        if (currentHealth > 4)
        {
            criticalHeartSource.Stop();
        }
    }

    void UpdateHealthUI()
    {
        hpText.text = "" + currentHealth;
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                StartCoroutine(Die());
            }

            if (currentHealth < 4)
            {
                criticalHeartSource.Play();
            }

            isInvincible =true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void TakeHealth(int health)
    {
        currentHealth += health;
        UpdateHealthUI();
    }

    public IEnumerator Die()
    {
        overSource.Play();
        yield return new WaitForSeconds(0.1f);
        gameOverUI.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}