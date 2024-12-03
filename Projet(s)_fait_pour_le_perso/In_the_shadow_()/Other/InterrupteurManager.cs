using UnityEngine;

public class InterrupteurManager : MonoBehaviour
{
    public GameObject toucheX;
    public GameObject toucheCarré;

    public GameObject platforme;
    public GameObject Lumiere;

    public SpriteRenderer interrupteur1;
    public SpriteRenderer interrupteur2;

    private bool playerInTrigger = false;

    private void Start()
    {
        platforme.SetActive(false);
        Lumiere.SetActive(true);
        toucheX.SetActive(false);
        toucheCarré.SetActive(false);
        interrupteur2.enabled = false;
        interrupteur1.enabled = true;

    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
        {
            platforme.SetActive(true);
            Lumiere.SetActive(false);
            interrupteur1.enabled = false;
            interrupteur2.enabled = true;
        }

        if (playerInTrigger && Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            platforme.SetActive(true);
            Lumiere.SetActive(false);
            interrupteur1.enabled = false;
            interrupteur2.enabled = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toucheX.SetActive(true);
            toucheCarré.SetActive(true);
            playerInTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toucheX.SetActive(false);
            toucheCarré.SetActive(false);
            playerInTrigger = false;
        }
    }
}