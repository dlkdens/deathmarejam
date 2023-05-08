using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMain : MonoBehaviour
{
    public Animator pBody, pLegs;

    // Update is called once per frame
    void FixedUpdate()
    {
        pLegs.SetFloat("x", Mathf.Abs(PlayerMov.Instance.inputAxis));
        pBody.SetFloat("x", Mathf.Abs(PlayerMov.Instance.inputAxis));
    }
}
