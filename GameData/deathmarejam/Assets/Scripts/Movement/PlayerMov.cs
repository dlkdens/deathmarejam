using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // F�sica do corpo do jogador
    public Rigidbody2D per_corpo;

    // Velocidade que o jogador se locomove
    public float vel;

    // For�a do pulo do jogador
    public float forcaPulo;

    public LayerMask chao;

    // Dire��o que o jogador est� virado/indo
    private float dir;

    private bool colideParede = false;
    private bool estaNoChao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // <- = -1
        // -> = 1
        dir = Input.GetAxisRaw("Horizontal");

        // Movimento b�sico do jogador, adiciona velocidade no eixo X
        per_corpo.velocity = new Vector2(dir * vel, per_corpo.velocity.y);

        // Pulo do jogador caso o mesmo pressione a Barra de Espa�o
        if(Input.GetKeyDown(KeyCode.Space) && estaNoCh�o)
        {
            // Adiciona a velocidade no eixo Y (cima) multiplicado pela for�a do pulo
            per_corpo.velocity = Vector2.up * forcaPulo;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "parede")
            colideParede = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "parede")
            colideParede = false;
    }
}