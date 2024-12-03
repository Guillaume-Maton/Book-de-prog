using UnityEngine;

public class DestructKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
        }
    }
}
