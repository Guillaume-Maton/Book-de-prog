using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject rouge;
    public GameObject vert;

    private void Start()
    {
        rouge.SetActive(true);
        vert.SetActive(false);
    }

    private void Awake()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            respawnPoint = transform.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
            rouge.SetActive(false);
            vert.SetActive(true);
        }
    }
}