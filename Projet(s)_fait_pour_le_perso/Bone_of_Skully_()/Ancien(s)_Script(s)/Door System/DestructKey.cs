using UnityEngine;

public class DestructKey : MonoBehaviour
{
    public Key KC;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KC.keyCount--;
        }
    }
}