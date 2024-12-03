using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Cible"))
        {
            Destroy(transform.gameObject);
        }
    }
}