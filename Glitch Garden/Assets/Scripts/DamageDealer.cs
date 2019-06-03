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


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageReceiver damageReceiver = other.gameObject.GetComponentInChildren<DamageReceiver>();
        if (!damageReceiver) { return; }


        if (other.gameObject.tag == playerTag)
        {
            if (shouldDestroyPlayers)
            {
                damageReceiver.TakeDamage(damage);
                
                Impact();
            }
        }

        if (other.gameObject.tag == enemyTag)
        {
            if (shouldDestroyEnemies)
            {
                damageReceiver.TakeDamage(damage);

                Impact();
            }
        }
    }


    public void Impact()
    {
        Destroy(gameObject);
    }
}
