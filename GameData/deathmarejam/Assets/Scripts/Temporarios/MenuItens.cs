using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItens : MonoBehaviour
{
    public GameObject creditsMenu;

    public void SwitchCreditsMenu(bool i)
    {
        creditsMenu.SetActive(i);
    }

}
