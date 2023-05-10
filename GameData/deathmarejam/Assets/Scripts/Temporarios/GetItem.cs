using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(this.gameObject.name == "pistolGet" )
            {
                PlayerManager.Instance.playerHand[0] = true;
                PlayerManager.Instance.pistolObj.SetActive(true);
            }
                
            else if(this.gameObject.name == "blasterGet")
                PlayerManager.Instance.playerHand[1] = true;

            Destroy(gameObject);
        }
        
    }
}
