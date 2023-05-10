using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool[] playerHand = {false, false};
    public int selectGun;
    private int lastGun;

    public GameObject pistolObj, blasterObj;
    public GameObject notifyObj;

    // Secao de instancia caso eu precise usar alguma variavel publica daqui (eu vou sim)
    public static PlayerManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        pistolObj.SetActive(false);
        blasterObj.SetActive(false);
        notifyObj.SetActive(false);
        selectGun = 0;
    }

    void Update()
    {
        if ((Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.X)) && selectGun != 0)
        {
            selectGun = 0;
            //HandCheck(selectGun);
        }
        else if (Input.GetKeyDown("2") && playerHand[0])
        {
            selectGun = 1;
            //HandCheck(selectGun);
            lastGun = 1;
        }
        else if (Input.GetKeyDown("3") && playerHand[1])
        {
            selectGun = 2;
            //HandCheck(selectGun);
            lastGun = 2;
        }
        else if ((!playerHand[0] && selectGun == 1) || (!playerHand[1] && selectGun == 2))
        {
            selectGun = 0;
            //HandCheck(selectGun);
        }

        else if(selectGun == 0 && Input.GetKeyDown(KeyCode.X))
        {
            selectGun = lastGun;
            //HandCheck(selectGun);
        }

        HandCheck(selectGun);


        
    }

    void HandCheck(int num)
    {
        switch(num)
        {
            case 0:
                if(playerHand[0])
                    pistolObj.SetActive(true);
                if(playerHand[1])
                    blasterObj.SetActive(true);
                PlayerMov.Instance.SwitchJump(false);
            break;

            case 1:
                if(playerHand[0])
                    pistolObj.SetActive(false);
                if(playerHand[1])
                    blasterObj.SetActive(true);
                PlayerMov.Instance.SwitchJump(true);
            break;

            case 2:
                if(playerHand[0])
                    pistolObj.SetActive(true);
                if(playerHand[1])
                    blasterObj.SetActive(false);
                PlayerMov.Instance.SwitchJump(true);
            break;
        }
        
    }

    public void NotifyPlayer(bool n)
    {
        if(transform.localEulerAngles.y == 0)
            notifyObj.GetComponent<SpriteRenderer>().flipX = false;
        else
            notifyObj.GetComponent<SpriteRenderer>().flipX = true;
        
        notifyObj.SetActive(n);
    }
}
