using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthEnemy;
    public GameObject player;
    private Animator enemyAnim;
    public bool flip;
    public float speed;
    private bool die;

    void Start()
    {
        die = false;
        enemyAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthEnemy > 0)
        {
            Vector3 scale = transform.localScale;
            if(Vector2.Distance(player.transform.position, transform.position) < 30)
            {
                enemyAnim.SetTrigger("move");
                if(player.transform.position.x > transform.position.x)
                {
                    scale.x = Mathf.Abs(scale.x) * -1f * (flip ? -1 : 1);
                    transform.Translate(speed * Time.deltaTime, 0f, 0f);
                }     
                else
                {
                    scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                    transform.Translate(speed * Time.deltaTime * -1, 0f, 0f);
                }
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
            //this.gameObject.GetComponent<Collider2D>().enabled = false;
            enemyAnim.SetTrigger("die");
            Destroy(this.gameObject, 0.9f);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            healthEnemy -= 50;
        }
           
    }
}
