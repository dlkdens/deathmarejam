using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool[] playerHand = {false, false};
    public int selectGun;
    private int lastGun;

    public GameObject pistolObj, blasterObj;
    public GameObject notifyObj;

    public float healthPlayer;
    public float healthMax;
    public Image fillHealth;

    public List<GameObject> playerCorpse = new List<GameObject>();
    public GameObject hitSprite;

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
        if(healthPlayer <= 0)
        {
            SceneControl.Instance.panelLose.SetActive(true);
            Time.timeScale = 0;
            PlayerMov.Instance.playerCanMove = false;
        }
        if(PlayerMov.Instance.playerCanMove)
        {
            if ((Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.X)) && selectGun != 0)
            {
                selectGun = 0;
            }
            else if (Input.GetKeyDown("2") && playerHand[0])
            {
                selectGun = 1;
                lastGun = 1;
            }
            else if (Input.GetKeyDown("3") && playerHand[1])
            {
                selectGun = 2;
                lastGun = 2;
            }
            else if ((!playerHand[0] && selectGun == 1) || (!playerHand[1] && selectGun == 2))
            {
                selectGun = 0;
            }

            else if(selectGun == 0 && Input.GetKeyDown(KeyCode.X))
            {
                selectGun = lastGun;
            }

            HandCheck(selectGun);
        }   
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

    public void PlayerGetDamage(float damage)
    {
        float direction;

        if(transform.localEulerAngles.y == 0)
            direction = -1;
        else
            direction = 1;
        
        healthPlayer -= damage;
        fillHealth.fillAmount = healthPlayer / healthMax;
        PlayerMov.Instance.rb_corpo.AddForce(Vector2.right * direction * 21f, ForceMode2D.Impulse);

        StartCoroutine("PlayerTomou");

    }

    private IEnumerator PlayerTomou()
    {
        // foreach(GameObject i in playerCorpse)
        //     i.SetActive(false);
        
        PlayerMov.Instance.playerCanMove = false;
        // hitSprite.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);

        // foreach(GameObject i in playerCorpse)
        //     i.SetActive(true);
        
        PlayerMov.Instance.playerCanMove = true;
        // hitSprite.SetActive(false);
    }
}
