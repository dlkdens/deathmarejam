using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMain : MonoBehaviour
{
    // Secao de instancia caso eu precise usar alguma variavel publica daqui (eu vou sim)
    public static AnimationPlayerMain Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Animator pBody, pLegs;
    public RuntimeAnimatorController pBodyCtrl, pBodyGun1, pBodyGun2;

    // Update is called once per frame
    void Update()
    {
        if(PlayerMov.Instance.playerCanMove)
        {
            // Corpo
            switch(PlayerManager.Instance.selectGun) 
            {
                case 0:
                    pBody.runtimeAnimatorController = pBodyCtrl;
                    pBody.SetFloat("x", Mathf.Abs(PlayerMov.Instance.inputAxis));
                    pBody.SetFloat("y", PlayerMov.Instance.rb_corpo.velocity.y);
                    pBody.SetBool("isGrounded", PlayerMov.Instance.isGrounded);
                break;

                case 1:
                    pBody.runtimeAnimatorController = pBodyGun1;
                break;

                case 2:
                    pBody.runtimeAnimatorController = pBodyGun2;
                break;
            }

            // Pernas
            pLegs.SetFloat("x", Mathf.Abs(PlayerMov.Instance.inputAxis));
            pLegs.SetFloat("y", PlayerMov.Instance.rb_corpo.velocity.y);
            pLegs.SetBool("isGrounded", PlayerMov.Instance.isGrounded);
        }

        else
        {
            if(PlayerManager.Instance.selectGun == 0)
            {
                pBody.SetFloat("x", 0f);
                pBody.SetFloat("y", PlayerMov.Instance.rb_corpo.velocity.y);
                pBody.SetBool("isGrounded", PlayerMov.Instance.isGrounded);
            }
            
            
            pLegs.SetFloat("x", 0f);
            pLegs.SetFloat("y", PlayerMov.Instance.rb_corpo.velocity.y);
            pLegs.SetBool("isGrounded", PlayerMov.Instance.isGrounded);
        }
        
    }
}
