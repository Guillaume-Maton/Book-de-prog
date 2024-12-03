using System.Collections;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target; // La cible que la caméra doit suivre
    public Vector3 offset; // Décalage spatial entre la caméra et la cible
    public float smoothSpeed = 0.125f; // Vitesse de l'effet "smooth" pour le suivi de la caméra
    public float lookAheadDistance = 5f; // Distance à regarder devant la cible
    public bool Detached;

    void Start()
    {
        Detached = false;
    }
    void FixedUpdate()
    {
        if (!Detached)
        {
            StartCoroutine(WaitOneSec());
            // Calcule la position cible de la caméra basée sur l'offset et la rotation de la cible
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Calcule la position à regarder en ajoutant un décalage devant la cible
            Vector3 lookAheadPosition = target.position + target.forward * lookAheadDistance;

            // Applique la position lissée à la caméra
            transform.position = smoothedPosition;

            // Fait en sorte que la caméra regarde la position décalée devant la cible
            transform.LookAt(lookAheadPosition);
        }

        if (Detached)
        {
            // Calcule la position cible de la caméra basée sur l'offset et la rotation de la cible
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Calcule la position à regarder en ajoutant un décalage devant la cible
            Vector3 lookAheadPosition = target.position + target.forward * lookAheadDistance;

            // Fait en sorte que la caméra regarde la position décalée devant la cible
            transform.LookAt(lookAheadPosition);
        }


    }

    public IEnumerator WaitOneSec()
    {
        yield return new WaitForSeconds(3f);
        smoothSpeed = 0.125f;

    }
}