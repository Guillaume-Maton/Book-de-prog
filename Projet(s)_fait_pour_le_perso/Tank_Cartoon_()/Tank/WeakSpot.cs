using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public CibleCount bc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            bc.Count++;
            Destroy(transform.gameObject);
        }
    }
}