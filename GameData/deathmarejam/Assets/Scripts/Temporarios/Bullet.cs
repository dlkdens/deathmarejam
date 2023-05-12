using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce;
    private float direction;
    private Rigidbody2D bltRB;
    void Start()
    {
        if(PlayerManager.Instance.transform.localEulerAngles.y == 0) direction = 1;
        else direction = -1;
        bltRB = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerManager.Instance.GetComponent<Collider2D>());
        Physics2D.IgnoreLayerCollision(0,3);
        Physics2D.IgnoreLayerCollision(3,3);

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += new Vector3(bulletForce * direction * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }  
}
