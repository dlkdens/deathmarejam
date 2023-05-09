using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMain : MonoBehaviour
{
    public Animator pBody, pLegs;
    public RuntimeAnimatorController pBodyCtrl, pBodyGun1, pBodyGun2;

    // Update is called once per frame
    void Update()
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
}
