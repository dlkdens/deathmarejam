using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMain : MonoBehaviour
{
    public bool playerUpside = false;
    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerUpside && Input.GetAxisRaw("Vertical") == -1 && PlayerMov.Instance.playerCanMove)
            coll.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "playerFeet")
        {
            StopCoroutine("ResetCollider");
            playerUpside = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "playerFeet")
            StartCoroutine("ResetCollider");
            
    }

    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(0.75f);
        playerUpside = false;
        coll.enabled = true;
    }
}
