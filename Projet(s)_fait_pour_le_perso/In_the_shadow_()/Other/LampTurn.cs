using UnityEngine;

public class LampTurn : MonoBehaviour
{
    public float rotationSpeed = 45f;

    private bool autoRotate;


    void Start()
    {
        ToggleAutoRotation();
    }

    void Update()
    {
        if (autoRotate)
        {
            this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    private void ToggleAutoRotation()
    {
        this.autoRotate = !this.autoRotate;
    }
}
