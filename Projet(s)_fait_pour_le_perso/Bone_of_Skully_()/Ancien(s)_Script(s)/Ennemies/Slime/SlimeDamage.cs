using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public AudioSource damageSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(3);
            damageSource.Play();
        }
    }
}