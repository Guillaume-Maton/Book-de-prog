using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private bool flipX;

    [SerializeField] private float PoingRange;
    [SerializeField] private Transform PoingDroit;
    [SerializeField] private Transform PoingGauche;
    [SerializeField] private SpriteRenderer PoingD;
    [SerializeField] private SpriteRenderer PoingG;

    [SerializeField] private float FeetRange;
    [SerializeField] private Transform FeetDroit;
    [SerializeField] private Transform FeetGauche;
    [SerializeField] private SpriteRenderer FeetD;
    [SerializeField] private SpriteRenderer FeetG;

    [SerializeField] private float SpecialRange;
    [SerializeField] private Transform SpecialDroit;
    [SerializeField] private Transform SpecialGauche;
    [SerializeField] private SpriteRenderer SpecialD;
    [SerializeField] private SpriteRenderer SpecialG;

    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private SpriteRenderer Idle;

    private void Start()
    {
        Idle.enabled = true;
        PoingD.enabled = false;
        PoingG.enabled = false;
        FeetD.enabled = false;
        FeetG.enabled = false;
        SpecialD.enabled = false;
        SpecialG.enabled = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput != 0)
        {
            flipX = horizontalInput < 0;
        }

        ///
        if (Input.GetButtonDown("Poing Attack"))
        {
            if (!flipX)
            {
                StartCoroutine(AttackDPoing());
                Debug.Log("Poing Droit Attacking");
            }
            else
            {
                StartCoroutine(AttackGPoing());
                Debug.Log("Poing Gauche Attacking");
            }
        }

        ///
        if (Input.GetButtonDown("Feet Attack"))
        {
            if (!flipX)
            {
                StartCoroutine(AttackDFeet());
                Debug.Log("Feet Droit Attacking");
            }
            else
            {
                StartCoroutine(AttackGFeet());
                Debug.Log("Feet Gauche Attacking");
            }
        }

        ///
        if (Input.GetButtonDown("Special Attack"))
        {
            if (!flipX)
            {
                StartCoroutine(AttackDSpecial());
                Debug.Log("Special Droit Attacking");
            }
            else
            {
                StartCoroutine(AttackGSpecial());
                Debug.Log("Special Gauche Attacking");
            }
        }
    }

    private IEnumerator AttackDPoing()
    {
        PoingDAttacking();
        Idle.enabled = false;
        PoingD.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        PoingD.enabled = false;
    }

    private IEnumerator AttackGPoing()
    {
        PoingGAttacking();
        Idle.enabled = false;
        PoingG.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        PoingG.enabled = false;
    }

    private IEnumerator AttackDFeet()
    {
        FeetDAttacking();
        Idle.enabled = false;
        FeetD.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        FeetD.enabled = false;
    }

    private IEnumerator AttackGFeet()
    {
        FeetGAttacking();
        Idle.enabled = false;
        FeetG.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        FeetG.enabled = false;
    }

    private IEnumerator AttackDSpecial()
    {
        SpecialDAttacking();
        Idle.enabled = false;
        SpecialD.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        SpecialD.enabled = false;
    }

    private IEnumerator AttackGSpecial()
    {
        SpecialGAttacking();
        Idle.enabled = false;
        SpecialG.enabled = true;
        yield return new WaitForSeconds(1);
        Idle.enabled = true;
        SpecialG.enabled = false;
    }

    private void PoingDAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PoingDroit.position, PoingRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(3);

        }
    }

    private void PoingGAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PoingGauche.position, PoingRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(3);

        }
    }

    private void FeetDAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(FeetDroit.position, FeetRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(3);

        }
    }

    private void FeetGAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(FeetGauche.position, FeetRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(3);

        }
    }

    private void SpecialDAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(SpecialDroit.position, SpecialRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(5);

        }
    }

    private void SpecialGAttacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(SpecialGauche.position, SpecialRange, PlayerLayer);

        foreach (Collider2D enemyHealth in hitEnemies)
        {

            enemyHealth.transform.GetComponent<EnemyHealth>().TakeDamage(5);

        }
    }

    private void OnDrawGizmos()
    {
        if (PoingDroit == null)
            return;

        if (PoingGauche == null)
            return;

        if (FeetDroit == null)
            return;

        if (FeetGauche == null)
            return;

        if (SpecialDroit == null)
            return;

        if (SpecialGauche == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PoingDroit.position, PoingRange);
        Gizmos.DrawWireSphere(PoingGauche.position, PoingRange);
        Gizmos.DrawWireSphere(FeetDroit.position, FeetRange);
        Gizmos.DrawWireSphere(FeetGauche.position, FeetRange);
        Gizmos.DrawWireSphere(SpecialDroit.position, SpecialRange);
        Gizmos.DrawWireSphere(SpecialGauche.position, SpecialRange);
    }
}