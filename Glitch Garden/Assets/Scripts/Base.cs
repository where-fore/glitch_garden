using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int health = 10;
    public int GetHealth() { return health; }

    private int healthToLosePerAttacker = 1;

    private float delayBeforeLoseGameScreen = 2.5f;

    private SceneLoader sceneLoaderObject = null;
    private HealthDisplay healthDisplayObject = null;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {
            LoseHealth(healthToLosePerAttacker);
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

        if (health <= 0)
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        sceneLoaderObject.LoadGameOverScreen(delayBeforeLoseGameScreen);
    }
}
