using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour
{
    public string passcode; // Código de acesso
    private string input = ""; // String de entrada do jogador
    public GameObject textKeypad;
    public Animator door1;

    public void ButtonClick(string value)
    {
        if (value == "C") // Botão de Limpar
        {
            input = "";
        }
        else if (value == "Enter") // Botão de Confirmar
        {
            if (input == passcode)
            {
                InteractList.Instance.KeypadSwitch(false);
                InteractList.Instance.DestructColliderDoor1();
                door1.SetTrigger("open");
                // Faça aqui o que deseja realizar ao inserir o código correto
            }
            else
            {
                // Faça aqui o que deseja realizar ao inserir o código incorreto
            }
            
            input = ""; // Limpa a entrada após o jogador pressionar Enter
        }
        else
        {
            input += value; // Concatena o valor do botão pressionado na entrada
        }

        textKeypad.GetComponent<Text>().text = input;
    }
}
