using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int CurrentHealth;

    [SerializeField] private float invincibilityFlashDelay;
    [SerializeField] private float invincibilityTimeAfterHit;
    [SerializeField] private bool isInvincible = false;

    [SerializeField] private GameObject EnemyRats;
    [SerializeField] private GameObject EnemyCanvas;
    [SerializeField] private SpriteRenderer EnemyEnemy;

    [SerializeField] private EnemyHealthBar EnemyHealthBar;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        EnemyHealthBar.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            CurrentHealth -= damage;
            EnemyHealthBar.SetHealth(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Die();
                Debug.Log("Ennemy is dead !");
            }

            if (CurrentHealth < 3)
            {
                Debug.Log("Ennemy is very special !");
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    private IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            EnemyEnemy.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            EnemyEnemy.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    private IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

    private void Die()
    {
        EnemyRats.SetActive (false);
        EnemyCanvas.SetActive(false);
    }
}