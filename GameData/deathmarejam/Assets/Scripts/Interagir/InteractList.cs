using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractList : MonoBehaviour
{
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

        ventilacaoAnim.SetTrigger("open");

        yield return new WaitForSeconds(1f);

        tutorialMonster.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        CameraFollow.Instance.offset.x = 0;
        CameraFollow.Instance.offset.y = 0;
        PlayerMov.Instance.playerCanMove = true;

    }

    #endregion
}
