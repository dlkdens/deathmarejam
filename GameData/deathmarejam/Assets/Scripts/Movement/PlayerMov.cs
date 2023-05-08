using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    // Velocidade que o jogador se locomove
    public float moveSpeed;
    // For�a do pulo do jogador
    public float jumpForce;
    // For�a do deslize na parede
    public float wallSlideSpeed;
    // Layer do ch�o
    public LayerMask groundLayer;

    // F�sica e colisor do corpo do jogador
    private Rigidbody2D rb_corpo;
    private Collider2D col;

    // Verifica se o jogador est� no ch�o e colidindo com a parede
    private bool isGrounded = false;
    private bool isCollidingWithWall = false;

    public Transform posPe;

    // � executado APENAS no primeiro frame ap�s a cena ser carregada
    void Start()
    {
        rb_corpo = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(posPe.position, 0.3f, groundLayer);

        // Verifica se o jogador est� no ch�o e se pressionou o bot�o de espa�o para realizar a a��o de pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            rb_corpo.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, rb_corpo.velocity.y);

        if (isCollidingWithWall && !isGrounded && rb_corpo.velocity.y < 0f)
            movement = new Vector2(moveHorizontal * wallSlideSpeed, rb_corpo.velocity.y);

        rb_corpo.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "parede")
            isCollidingWithWall = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "parede")
            isCollidingWithWall = false;
    }
}