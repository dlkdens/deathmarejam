using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool[] playerHand = {false, false};
    public int selectGun;

    // Seção de instância caso eu precise usar alguma variável pública daqui (eu vou sim)
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
        selectGun = 0;
    }

    void Update()
    {
        if ((Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.X)))
        {
            selectGun = 0;
        }
        else if (Input.GetKeyDown("2") && playerHand[0])
        {
            selectGun = 1;
        }
        else if (Input.GetKeyDown("3") && playerHand[1])
        {
            selectGun = 2;
        }
        else if ((playerHand[0] == false && selectGun == 1) || (playerHand[1] == false && selectGun == 2))
            selectGun = 0;
        
    }
}
