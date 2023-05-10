using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEffect : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D capRB;
    public float fadeTime = 1f;
    private float currentTime = 0f;
    public float capForce = 5f;

    private AudioSource source;
    public AudioClip clip;

    private bool tocaChao;

    void Start()
    {
        tocaChao = false;

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerManager.Instance.GetComponent<Collider2D>());
        

        sr = GetComponent<SpriteRenderer>();
        capRB = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        transform.localEulerAngles = new Vector3(0f,0f,Random.Range(0f,360f));

        if(PlayerManager.Instance.transform.localEulerAngles.y == 0)
            capRB.AddForce(new Vector2(-1.2f, 1f) * capForce, ForceMode2D.Impulse);
        else
            capRB.AddForce(new Vector2(1.2f, 1f) * capForce, ForceMode2D.Impulse);
        
        Destroy(gameObject, 9f);
    }

    void FixedUpdate()
    {
        if(tocaChao)
        {
            if (currentTime < fadeTime)
            {
                currentTime += Time.deltaTime;
                float alpha = 1 - currentTime / fadeTime;
                Color color = sr.color;
                color.a = alpha;
                sr.color = color;
            }
            else
             Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 6 || other.gameObject.layer == 7)
        {
            source.PlayOneShot(clip);
            tocaChao = true;
        }
    }
}
