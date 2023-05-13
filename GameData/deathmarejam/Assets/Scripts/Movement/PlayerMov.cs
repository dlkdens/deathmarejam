using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    // Velocidade que o jogador se locomove
    public float moveSpeed;
    // Direcao que o jogador esta olhando
    public float inputAxis;

    [Header("Pulo do Jogador")]
    // Forca do pulo do jogador - WG -> without gun
    public float jumpWG; 
    public float jumpGun;
    private float jumpForce;

    // Layer do chao
    public LayerMask groundLayer;

    // Fisica e colisor do corpo do jogador
    public Rigidbody2D rb_corpo;

    // Verifica se o jogador esta no chao
    public bool isGrounded = false;
    public bool playerCanMove;

    public Transform posPe;

    // Secao de instancia caso eu precise usar alguma variavel publica daqui (eu vou sim)
    public static PlayerMov Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // E executado APENAS no primeiro frame apos a cena ser carregada
    void Start()
    {
        playerCanMove = true;
        isGrounded = false;
        jumpForce = jumpWG;
        rb_corpo = GetComponent<Rigidbody2D>();
    }

    // E executado TODO frame
    void Update()
    {
        // Verifica se o jogador esta no chao e se pressionou o botao de espaao para realizar a acao de pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && playerCanMove)
        {

            isGrounded = false;
            rb_corpo.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
            

        // Direcaoo que o jogador esta indo/olhando
        inputAxis = Input.GetAxisRaw("Horizontal");

        if (inputAxis > 0 && playerCanMove)
            transform.eulerAngles = new Vector2(0f, 0f);
        if (inputAxis < 0 && playerCanMove)
            transform.eulerAngles = new Vector2(0f, 180f);

    }

    // Chamado a cada intervalo fixo, bom pra usar pra calculo de fisica, colisoes e movimentos
    void FixedUpdate()
    {
        if(playerCanMove)
        {
            Vector3 movement = new Vector3(inputAxis, 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }

    public void SwitchJump(bool gun)
    {
        if(gun)
            jumpForce = jumpGun;
        else
            jumpForce = jumpWG;
    }

}