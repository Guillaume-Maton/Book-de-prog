using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;

    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1, 0);
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
        }
    }
}
