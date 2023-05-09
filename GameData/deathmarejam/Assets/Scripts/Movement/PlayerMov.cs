using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    // Velocidade que o jogador se locomove
    public float moveSpeed;
    // Direção que o jogador está olhando
    public float inputAxis;
    // Força do pulo do jogador
    public float jumpForce;
    // Layer do chão
    public LayerMask groundLayer;

    // Física e colisor do corpo do jogador
    public Rigidbody2D rb_corpo;

    // Verifica se o jogador está no chão
    public bool isGrounded = false;

    public Transform posPe;

    // Seção de instância caso eu precise usar alguma variável pública daqui (eu vou sim)
    public static PlayerMov Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // É executado APENAS no primeiro frame após a cena ser carregada
    void Start()
    {
        rb_corpo = GetComponent<Rigidbody2D>();
    }

    // É executado TODO frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(posPe.position, 0.3f, groundLayer);

        // Verifica se o jogador está no chão e se pressionou o botão de espaço para realizar a ação de pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            isGrounded = false;
            rb_corpo.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
            

        // Direção que o jogador está indo/olhando
        inputAxis = Input.GetAxisRaw("Horizontal");

        if (inputAxis > 0)
            transform.eulerAngles = new Vector2(0f, 0f);
        if (inputAxis < 0)
            transform.eulerAngles = new Vector2(0f, 180f);

    }

    // Chamado a cada intervalo fixo, bom pra usar pra calculo de física, colisões e movimentos
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(inputAxis, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

}