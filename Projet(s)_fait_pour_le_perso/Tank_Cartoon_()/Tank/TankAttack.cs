using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public Canon canon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            canon.Fire();
        }
    }
}