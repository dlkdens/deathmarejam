using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    // Velocidade que o jogador se locomove
    public float moveSpeed;
    // Força do pulo do jogador
    public float jumpForce;
    // Força do deslize na parede
    public float wallSlideSpeed;
    // Layer do chão
    public LayerMask groundLayer;

    // Física e colisor do corpo do jogador
    private Rigidbody2D rb_corpo;
    private Collider2D col;

    // Verifica se o jogador está no chão e colidindo com a parede
    private bool isGrounded = false;
    private bool isCollidingWithWall = false;

    public Transform posPe;

    // É executado APENAS no primeiro frame após a cena ser carregada
    void Start()
    {
        rb_corpo = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(posPe.position, 0.3f, groundLayer);

        // Verifica se o jogador está no chão e se pressionou o botão de espaço para realizar a ação de pular
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