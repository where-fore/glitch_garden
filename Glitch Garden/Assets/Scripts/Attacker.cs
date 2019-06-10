using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int damage = 0;
    private float currentSpeed = 0f;
    public void SetMovementSpeed(float newSpeed) {currentSpeed = newSpeed;}
    private GameObject currentTarget = null;

    private Animator myAnimatorComponent = null;
    private string isAttackingAnimationParameterStringReference = "ShouldAttack";

    private void Start()
    {
        myAnimatorComponent = GetComponent<Animator>();
    }


    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            myAnimatorComponent.SetBool(isAttackingAnimationParameterStringReference, false);
        }
    }

    public void Attack(GameObject target)
    {
        myAnimatorComponent.SetBool(isAttackingAnimationParameterStringReference, true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }

        DamageReceiver targetDamageReceiverComponent = currentTarget.GetComponent<DamageReceiver>();

        if (targetDamageReceiverComponent)
        {
            targetDamageReceiverComponent.TakeDamage(damage);
        }
    }

}
