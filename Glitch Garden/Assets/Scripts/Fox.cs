using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Animator myAnimatorComponent = null;
    
    private string jumpAnimationParameterStringReference = "JumpTrigger";

    private void Start()
    {
        myAnimatorComponent = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            CallJumpTrigger();
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    private void CallJumpTrigger()
    {
        myAnimatorComponent.SetTrigger(jumpAnimationParameterStringReference);
    }
}
