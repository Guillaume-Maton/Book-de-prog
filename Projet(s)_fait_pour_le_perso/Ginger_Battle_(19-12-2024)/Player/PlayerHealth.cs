using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int CurrentHealth;

    [SerializeField] private float InvincibilityFlashDelay;
    [SerializeField] private float InvincibilityTimeAfterHit;
    [SerializeField] private bool IsInvincible = false;

    [SerializeField] private SpriteRenderer PlayerSprite;
    [SerializeField] private GameObject CanvasBar;

    [SerializeField] private PlayerHealthBar PlayerHealthBar;

    public bool isPaused = false;

    void Start()
    {
        CurrentHealth = MaxHealth;
        PlayerHealthBar.SetMaxHealth(MaxHealth);
    }

    public void HealPlayer(int amount)
    {
        if((CurrentHealth + amount) > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += amount;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!IsInvincible)
        {
            CurrentHealth -= damage;
            PlayerHealthBar.SetHealth(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Die();
            }

            if (CurrentHealth < 4)
            {
                Debug.Log("Player is very Special !");
            }

            IsInvincible =true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void TakeHealth(int health)
    {
        CurrentHealth += health;
    }

    private void Die()
    {
        CanvasBar.SetActive(false);
        PlayerSprite.enabled = false;
        SceneManager.LoadScene("Menu");
        Debug.Log("Player is Dead !");
    }

    public IEnumerator InvincibilityFlash()
    {
        while (IsInvincible)
        {
            PlayerSprite.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
            PlayerSprite.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvincibilityTimeAfterHit);
        IsInvincible = false;
    }
}