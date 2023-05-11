using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 6)
        {
            PlayerMov.Instance.isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == 6)
        {
            PlayerMov.Instance.isGrounded = false;
        }
    }
}
