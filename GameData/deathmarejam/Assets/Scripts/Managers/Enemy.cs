using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthEnemy;
    private Rigidbody2D rb_enemy;
    public GameObject player;
    private Animator enemyAnim;
    public bool flip;
    public float speed;
    private bool die;

    private float direction;

    public bool isBoss = false;

    void Start()
    {
        Time.timeScale = 1;
        Physics2D.IgnoreLayerCollision(8,8);
        die = false;
        enemyAnim = this.GetComponent<Animator>();
        rb_enemy = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.x > transform.position.x)
            direction = -1;
        else
            direction = 1;
        
        if(healthEnemy > 0)
        {
            Vector3 scale = transform.localScale;
            if(Vector2.Distance(player.transform.position, transform.position) < 30 && player.transform.position.x != transform.position.x)
            {
                enemyAnim.SetTrigger("move");
                scale.x = Mathf.Abs(scale.x) * direction;
                transform.Translate(speed * Time.deltaTime * -direction, 0f, 0f);
            }
            else
            {
                enemyAnim.SetTrigger("notmove");
            }
            transform.localScale = scale;
        }
        else if(!die)
        {
            die = true;
            rb_enemy.constraints = RigidbodyConstraints2D.FreezePosition;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            enemyAnim.SetTrigger("die");
            Destroy(this.gameObject, 0.9f);

            if(isBoss)
            {
                SceneControl.Instance.panelVic.SetActive(true);
                Time.timeScale = 0;
                PlayerMov.Instance.playerCanMove = false;
            } 
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet" && !die)
        {
            enemyAnim.SetTrigger("hit");
            rb_enemy.AddForce(Vector2.right * direction * 2f, ForceMode2D.Impulse);
            healthEnemy -= 50;
        }
           
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isBoss)  PlayerManager.Instance.PlayerGetDamage(100f);
            else PlayerManager.Instance.PlayerGetDamage(50f);
            
        }
    }
}
