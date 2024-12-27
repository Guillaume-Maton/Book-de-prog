using UnityEngine;

public class Déplacement : MonoBehaviour
{
    [SerializeField] private float HorizontalMoveSpeed;
    [SerializeField] private float VerticalMoveSpeed;

    [SerializeField] private Rigidbody2D RB;
    //[SerializeField] private Animator Animator;
    [SerializeField] private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        /// Permet de donner à rb le composant Rigidbody2D.
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /// Permet le déplacement sur la ligne Horizontal.
        float horizontalMoveInput = Input.GetAxis("Vertical");
        RB.velocity = new Vector2(horizontalMoveInput * HorizontalMoveSpeed, RB.velocity.y);

        /// Permet le déplacement sur la ligne Vertical.
        float verticalMoveInput = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(verticalMoveInput * VerticalMoveSpeed, RB.velocity.x);

        /// Permet d'appeler la fonction qui fait tourner le sprite du joueur selon si il est aller à droite ou à gauche.
        Flip(RB.velocity.x);

        /*/// Permet de faire jouer l'animation de course grâce à la float "HorizontalSpeed" de l'animator sur la ligne horizontal.
        float horizontalCharacterVelocity = Mathf.Abs(RB.velocity.x);
        Animator.SetFloat("HorizontalSpeed", horizontalCharacterVelocity);

        ///Permet de faire jouer l'animation de course grâce à la float "VerticalSpeed" de l'animator sur la ligne vertical;
        float verticalCharacterVelocity = Mathf.Abs(RB.velocity.y);
        Animator.SetFloat("VerticalSpeed", verticalCharacterVelocity);*/
    }

    private void Flip(float _velocity)
    {
        /// Si le joueur est au-dessus de 0.1 sur la ligne horizontal alors le sprite du joueur ne se tourne pas.
        if (_velocity > 0.1f)
        {
            SpriteRenderer.flipX = false;
        }

        /// Si le joueur est en-dessous de 0.1 sur la ligne horizontal alors le sprite du joueur se tourne.
        else if (_velocity < -0.1f)
        {
            SpriteRenderer.flipX = true;
        }
    }
}
