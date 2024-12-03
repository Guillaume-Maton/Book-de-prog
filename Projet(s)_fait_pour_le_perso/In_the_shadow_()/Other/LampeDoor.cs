using UnityEngine;

public class LampeDoor : MonoBehaviour
{
    public bool locked;
    public GameObject Lumiere;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            locked = false;
            Lumiere.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            locked = true;
            Lumiere.SetActive(true);
        }
    }
}