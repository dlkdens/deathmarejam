using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isRange;
    public KeyCode interactKey;
    public bool needKey = true;
    public UnityEvent interactAction;

    void LateUpdate()
    {
        if(isRange && needKey)
        {
            PlayerManager.Instance.NotifyPlayer(isRange);
            if(Input.GetKeyDown(interactKey))
                interactAction.Invoke();
        }
        else if(isRange)
        {
            interactAction.Invoke();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isRange = true;
        }
            
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isRange = false;
            PlayerManager.Instance.NotifyPlayer(isRange);
        }
            
    }
}
