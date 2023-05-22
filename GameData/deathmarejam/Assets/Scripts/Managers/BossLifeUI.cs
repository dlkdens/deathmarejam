using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeUI : MonoBehaviour
{
    public static BossLifeUI Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }
    
    public float bossMaxLife;
    public float bossLifeAtual;
    public Image fillLife;

    void Update()
    {
        fillLife.fillAmount = bossLifeAtual/bossMaxLife;
    }
}
