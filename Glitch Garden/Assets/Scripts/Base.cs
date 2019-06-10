using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int health = 10;

    private int healthToLosePerAttacker = 1;

    private float delayBeforeLoseGameScreen = 2.5f;

    private SceneLoader sceneLoaderObject = null;

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
    }

    public void LoseHealth(int amount)
    {
        health -= amount;
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
