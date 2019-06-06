using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 100;
    public int GetDamageValue() {return damage;}

    [SerializeField] private bool shouldDestroyPlayers = false;
    public bool GetDestroyPlayerBool() {return shouldDestroyPlayers;}

    [SerializeField] private bool shouldDestroyEnemies = false;
    
    public bool GetDestroyEnemiesBool() {return shouldDestroyEnemies;}

    private string playerTag = "Player";
    private string enemyTag = "Enemy";

    private void Start()
    {
        CheckBoxColliderProperties();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageReceiver damageReceiver = other.gameObject.GetComponentInChildren<DamageReceiver>();
        if (!damageReceiver) { return; }


        if (shouldDestroyPlayers && other.gameObject.tag == playerTag)
        {
            damageReceiver.TakeDamage(damage);
            
            Impact();
        }

        if (shouldDestroyEnemies && other.gameObject.tag == enemyTag)
        {
            damageReceiver.TakeDamage(damage);

            Impact();
        }
    }


    public void Impact()
    {
        if (transform.parent.GetComponent<Projectile>() != null)
        {
            Destroy(transform.parent.gameObject);
        }

        Destroy(gameObject);
    }
    
    private void CheckBoxColliderProperties()
    {
        BoxCollider2D myBoxCollider2D = GetComponent<BoxCollider2D>();
        
        if (!myBoxCollider2D) { Debug.Log("No BoxCollider2D found on me! Name: " + name); }

        if (myBoxCollider2D)
        {
            if (!myBoxCollider2D.isTrigger) { Debug.Log("My BoxCollider2D isn't a trigger! Name: " + name); }
        }
    }

}
