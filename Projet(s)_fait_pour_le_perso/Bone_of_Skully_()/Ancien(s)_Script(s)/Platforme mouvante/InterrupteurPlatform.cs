using UnityEngine;

public class InterrupteurPlatform : MonoBehaviour
{
    public GameObject toucheX;
    public GameObject plateformeMouvante;
    public SpriteRenderer interrupteur1;
    public SpriteRenderer interrupteur2;
    private bool playerInTrigger = false;

    private void Start()
    {
        toucheX.SetActive(false);
        plateformeMouvante.SetActive(false);
        interrupteur2.enabled = false;
        interrupteur1.enabled = true;
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
        {
            interrupteur1.enabled = false;
            interrupteur2.enabled = true;
            plateformeMouvante.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toucheX.SetActive(true);
            playerInTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toucheX.SetActive(false);
            playerInTrigger = false;
        }
    }
}