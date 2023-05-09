using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    // Velocidade que o jogador se locomove
    public float moveSpeed;
    // Dire��o que o jogador est� olhando
    public float inputAxis;
    // For�a do pulo do jogador
    public float jumpForce;
    // Layer do ch�o
    public LayerMask groundLayer;

    // F�sica e colisor do corpo do jogador
    public Rigidbody2D rb_corpo;

    // Verifica se o jogador est� no ch�o
    public bool isGrounded = false;

    public Transform posPe;

    // Se��o de inst�ncia caso eu precise usar alguma vari�vel p�blica daqui (eu vou sim)
    public static PlayerMov Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // � executado APENAS no primeiro frame ap�s a cena ser carregada
    void Start()
    {
        rb_corpo = GetComponent<Rigidbody2D>();
    }

    // � executado TODO frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(posPe.position, 0.3f, groundLayer);

        // Verifica se o jogador est� no ch�o e se pressionou o bot�o de espa�o para realizar a a��o de pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            isGrounded = false;
            rb_corpo.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
            

        // Dire��o que o jogador est� indo/olhando
        inputAxis = Input.GetAxisRaw("Horizontal");

        if (inputAxis > 0)
            transform.eulerAngles = new Vector2(0f, 0f);
        if (inputAxis < 0)
            transform.eulerAngles = new Vector2(0f, 180f);

    }

    // Chamado a cada intervalo fixo, bom pra usar pra calculo de f�sica, colis�es e movimentos
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(inputAxis, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

}