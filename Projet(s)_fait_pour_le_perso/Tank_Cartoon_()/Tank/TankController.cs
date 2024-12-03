using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    public Transform turret;
    public float joystickX;
    public float joystickY;
    public float sensitivity;

    private void FixedUpdate()
    {
        transform.position += transform.rotation * new Vector3(Input.GetAxis("Vertical"), 0, 0) * movementSpeed * Time.fixedDeltaTime;

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime, 0);

        joystickX = Input.GetAxis("joystick X") * sensitivity * Time.fixedDeltaTime;
        joystickY = Input.GetAxis("joystick Y") * sensitivity * Time.fixedDeltaTime;

        turret.Rotate(0, joystickX, 0);
        turret.Rotate(0, 0, joystickY);

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            turret.Rotate(-90f, 0f, -719f);
        }
    }
}