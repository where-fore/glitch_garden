using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public int GetHealth() { return health; }

    private int healthToLosePerAttacker = 1;

    private SceneLoader sceneLoaderObject = null;
    private HealthDisplay healthDisplayObject = null;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {
            LoseHealth(healthToLosePerAttacker);
            
            if (health <= 0)
            {
                KilledBy(otherCollider.transform.position);
            }
        }
    }

    private void Start()
    {
        sceneLoaderObject = FindObjectOfType<SceneLoader>();
        healthDisplayObject = FindObjectOfType<HealthDisplay>();
    }

    public void LoseHealth(int amount)
    {
        health -= amount;
        healthDisplayObject.UpdateText();
    }

    private void KilledBy(Vector3 killerPos)
    {
        FindObjectOfType<LevelManager>().LoseLevel(killerPos);
    }
}
