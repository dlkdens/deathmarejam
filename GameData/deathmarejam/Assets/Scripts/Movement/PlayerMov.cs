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
    private Rigidbody2D rb_corpo;

    // Verifica se o jogador está no chão
    private bool isGrounded = false;

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
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        inputAxis = Input.GetAxisRaw("Horizontal");

        if (inputAxis > 0)
            transform.eulerAngles = new Vector2(0f, 0f);
        if (inputAxis < 0)
            transform.eulerAngles = new Vector2(0f, 180f);
    }

}