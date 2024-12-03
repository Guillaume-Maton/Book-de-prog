using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioSource hitSlime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hitSlime.Play();
            Destroy(transform.parent.gameObject);
        }
    }
}