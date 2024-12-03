using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoPlateforme : MonoBehaviour
{
    public GameObject toucheX;
    public GameObject plateformeMouvante;
    public GameObject texteTuto;
    public TextMeshProUGUI textTuto;
    public SpriteRenderer interrupteur1;
    public SpriteRenderer interrupteur2;

    private bool playerInTrigger = false;

    private void Start()
    {
        toucheX.SetActive(false);
        texteTuto.SetActive(false);
        plateformeMouvante.SetActive(false);
        interrupteur1.enabled = true;
        interrupteur2.enabled = false;
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
        {
            interrupteur1.enabled = false;
            interrupteur2.enabled = true;
            texteTuto.SetActive(true);
            toucheX.SetActive(false);
            plateformeMouvante .SetActive(true);
        }
        textTuto.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toucheX.SetActive(true);
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
            toucheX.SetActive(false);
        }
    }
}