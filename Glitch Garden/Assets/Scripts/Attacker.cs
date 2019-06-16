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
    private AttackerSpawner mySpawner = null;

    private void Start()
    {
        myAnimatorComponent = GetComponent<Animator>();
        mySpawner = transform.parent.gameObject.GetComponent<AttackerSpawner>();
        mySpawner.IncrementAttackers();
    }


    void Update()
    {
        Move();

        if (!currentTarget)
        {
            myAnimatorComponent.SetBool(isAttackingAnimationParameterStringReference, false);
        }
    }

    private void OnDestroy()
    {
        mySpawner.DecrementAttackers();
    }

    private void Move()
    {
        float intensityMulti = PlayerPrefsController.GetIntensity() * 2;
        float baseTweak = 0.8f;

        Vector2 moveDelta = Vector2.left * currentSpeed * intensityMulti * baseTweak * Time.deltaTime;
        transform.Translate(moveDelta);
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
