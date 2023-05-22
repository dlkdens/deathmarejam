using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractList : MonoBehaviour
{
    // ESTE É UM CÓDIGO CHEIO, MAS CHEIO, MUITO CHEIO, DE GAMBIARRA, PROMETO DIMINUIR ELE QUANDO TIVER MAIS TEMPO, 
    // TEM MUITA VARIÁVEL QUE É DECLARADA REPETIDAS VEZES (exemplo de uma gambiarra q tem entre várias).

    public static InteractList Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Player")]
    public PlayerMov pmv;
    public PlayerManager pmngr;

    //GUARDA
    #region GUARDA_SCRIPT

    [Header("Guarda - 1")]
    public List<GameObject> dialogueGuardObj = new List<GameObject>();

    [TextArea(3,10)]
    public List<string> dialogueGuardTxt = new List<string>();
    public GameObject pistolUI;
    public GameObject guardTxt;
    public GameObject guard;
    public Animator guardAnim;

    public void GuardEvent(GameObject intObj)
    {
        Destroy(intObj);
        pmv.playerCanMove = false;
        guard.GetComponent<Collider2D>().enabled = false;
        
        StartCoroutine("GuardCoroutineEvent");
    }

    private IEnumerator GuardCoroutineEvent()
    {
        dialogueGuardObj[0].SetActive(true);
        dialogueGuardObj[1].SetActive(true);

        guardTxt.GetComponent<Text>().text = "";

        foreach(char letter in dialogueGuardTxt[0].ToCharArray())
        {
            guardTxt.GetComponent<Text>().text += letter;

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f);


        dialogueGuardObj[0].SetActive(false);

        yield return new WaitForSeconds(3f);

        guardAnim.SetTrigger("die");

        yield return new WaitForSeconds(3f);

        dialogueGuardObj[0].SetActive(true);
        guardTxt.GetComponent<Text>().text = "";
        dialogueGuardObj[1].SetActive(false);
        dialogueGuardObj[2].SetActive(true);

        foreach(char letter in dialogueGuardTxt[1].ToCharArray())
        {
            guardTxt.GetComponent<Text>().text += letter;

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f);

        guardAnim.SetTrigger("die_wg");

        pistolUI.SetActive(true);

        pmv.playerCanMove = true;
        pmngr.playerHand[0] = true;

        guardTxt.GetComponent<Text>().text = "";

        foreach(GameObject ob in dialogueGuardObj)
            ob.SetActive(false);
    }

    #endregion

    //PORTA 1 - Exposed pass
    #region SENHA_1_SCRIPT

    [Header("Senha da Porta 1")]
    public GameObject pass1Txt;
    public GameObject intObjPass1;

    [TextArea(3,10)]
    public string textToType;
    public List<GameObject> passDialogue = new List<GameObject>();

    public void Key1Event()
    {
        pmv.playerCanMove = false;
        intObjPass1.GetComponent<Collider2D>().enabled = false;
        
        StartCoroutine("Pass1Event");
    }

    private IEnumerator Pass1Event()
    {
        foreach(GameObject i in passDialogue)
            i.SetActive(true);

        pass1Txt.GetComponent<Text>().text = "";

        foreach(char letter in textToType)
        {
            pass1Txt.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f);

        foreach(GameObject i in passDialogue)
            i.SetActive(false);

        pmv.playerCanMove = true;
        intObjPass1.GetComponent<Collider2D>().enabled = true;
    }

    #endregion

    //KEYPAD - 1
    #region PORTA_1_SCRIPT

    [Header("Porta - 1")]

    public GameObject key1Obj;
    public GameObject keypadUI;

    public void KeypadSwitch(bool i)
    {
        key1Obj.GetComponent<Collider2D>().enabled = !i;
        pmv.playerCanMove = !i;
        keypadUI.SetActive(i);
    }

    public void DestructColliderDoor1()
    {
        key1Obj.GetComponent<Collider2D>().enabled = false;
    }

    #endregion

    //Evento Inimigo 1
    #region EVENTO_1_SCRIPT
    
    public Animator ventilacaoAnim;
    public GameObject tutorialMonster;

    public void Event01(GameObject objEvent)
    {
        Destroy(objEvent);

        StartCoroutine("Event1Cor");
    }

    private IEnumerator Event1Cor()
    {
        PlayerMov.Instance.playerCanMove = false;
        //Vai tocar um som
        yield return new WaitForSeconds(2f);
        CameraFollow.Instance.offset.x = 18;
        CameraFollow.Instance.offset.y = 5;

        yield return new WaitForSeconds(1f);

        ventilacaoAnim.SetTrigger("open");

        yield return new WaitForSeconds(1f);

        tutorialMonster.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        CameraFollow.Instance.offset.x = 0;
        CameraFollow.Instance.offset.y = 0;
        PlayerMov.Instance.playerCanMove = true;

    }

    #endregion

    //Evento Sala da Assistente
    #region EVENTO_ASSISTENTE_SCRIPT

    [Header("Assistente - 1")]

    [TextArea(3,10)]
    public List<string> falasAss = new List<string>();
    public List<GameObject> personsFala = new List<GameObject>();
    public GameObject nextInteract;
    public Text dialogueAssTxt;
    public Animator keypad2;
    public GameObject gunUI2;

    public List<Transform> spawnPositions = new List<Transform>();
    public List<GameObject> enemiesSpawn = new List<GameObject>();

    public void firstContactAss(GameObject assObjT)
    {
        Destroy(assObjT);
        pmv.playerCanMove = false;

        StartCoroutine("assDefense");
    }

    private IEnumerator assDefense()
    {
        dialogueAssTxt.text = "";
        personsFala[0].SetActive(true);
        personsFala[1].SetActive(true);

        foreach(char letter in falasAss[0].ToCharArray())
        {
            dialogueAssTxt.text += letter;

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f);

        personsFala[1].SetActive(false);
        personsFala[2].SetActive(true);

        dialogueAssTxt.text = "";

        foreach(char letter in falasAss[1].ToCharArray())
        {
            dialogueAssTxt.text += letter;

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(3f);

        personsFala[0].SetActive(false);
        personsFala[1].SetActive(false);
        personsFala[2].SetActive(false);
        personsFala[3].SetActive(false);
        personsFala[4].SetActive(false);

        personsFala[5].SetActive(true);

        pmv.playerCanMove = true;

        int timer = 0;

        while(timer <= 15)
        {
            Instantiate(enemiesSpawn[Random.Range(0,3)], spawnPositions[Random.Range(0,2)]);
            timer++;
            yield return new WaitForSeconds(6f);
        }


        yield return new WaitForSeconds(6f);
        
        personsFala[3].SetActive(true);
        personsFala[4].SetActive(true);

        personsFala[5].SetActive(false);

        nextInteract.SetActive(true);
    }

    public void secondContactAss()
    {
        Destroy(nextInteract);
        StartCoroutine("lastAssContact");
    }

    private IEnumerator lastAssContact()
    {
        pmv.playerCanMove = false;

        dialogueAssTxt.text = "";
        personsFala[0].SetActive(true);
        personsFala[1].SetActive(true);

        foreach(char i in falasAss[2])
        {
            dialogueAssTxt.text += i;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(6f);

        dialogueAssTxt.text = "";

        keypad2.SetTrigger("open");
        pmv.playerCanMove = true;
        pmngr.playerHand[1] = true;
        gunUI2.SetActive(true);

        dialogueAssTxt.text = "";
        personsFala[0].SetActive(false);
        personsFala[1].SetActive(false);

    }

    #endregion

    //Fechar a porta da sala do boss
    #region BOSS_DOOR_LOCK
    public Animator doorBoss;
    public GameObject bossUILifeIndicator;

    public void doorBossLock(GameObject i)
    {
        Destroy(i);
        doorBoss.SetTrigger("close");
        bossUILifeIndicator.SetActive(true);
    }
    #endregion
}
