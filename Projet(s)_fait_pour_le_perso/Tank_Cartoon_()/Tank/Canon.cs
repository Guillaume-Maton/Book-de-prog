using System.Collections;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Rigidbody tankBulletPrefab;
    public Transform viseur;
    public float rateOfFire;
    public float bulletSpeed;

    private bool shooting;

    public void Fire()
    {
        StartCoroutine(OneShot());
    }

    public void Shoot()
    {
        shooting = true;
        Rigidbody bullet = Instantiate(tankBulletPrefab, viseur.position, viseur.rotation);
        bullet.AddForce(viseur.forward * bulletSpeed, ForceMode.Impulse);
    }

    public void Reload()
    {
        shooting = false;
    }

    private IEnumerator OneShot()
    {
        if (!shooting)
        {
            Shoot();
            yield return new WaitForSeconds(rateOfFire);
            Reload();
        }
    }
}