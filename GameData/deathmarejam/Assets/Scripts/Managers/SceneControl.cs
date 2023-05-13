using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static SceneControl Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject panelVic;
    public GameObject panelLose;

    public void LoadFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void LoadVideo()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
