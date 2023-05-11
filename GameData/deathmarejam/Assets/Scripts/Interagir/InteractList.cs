using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractList : MonoBehaviour
{
    [Header("Player")]
    public PlayerMov pmv;
    public PlayerManager pmngr;

    [Header("Objetos para o guarda")]
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

        dialogueGuardObj[0].SetActive(false);
    }
}
