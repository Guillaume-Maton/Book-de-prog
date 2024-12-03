using UnityEngine;

public class Door: MonoBehaviour
{
    public KeyManager keyManager;
    public Key KC;
    public bool locked;
    public GameObject Porte;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyManager.isKey)
        {
            if (KC.keyCount > 0)
            {
                locked = false;
                Porte.SetActive(false);
            }
        }
    }
}