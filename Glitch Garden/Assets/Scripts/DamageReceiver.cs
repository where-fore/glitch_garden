using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private int health = 500;
    public int GetHealth() {return health;}

    [SerializeField] private GameObject deathVFX = null;
    [SerializeField] float deathVFXDuration = 1f;
    private SpriteRenderer mySpriteRenderer = null;
    private float colourFlashLength = 0.25f;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(FlashRed());

        if (health <= 0)
        {
            Die();
        }

    }

    private IEnumerator FlashRed()
    {
        mySpriteRenderer.color = Color.red;

        yield return new WaitForSeconds(colourFlashLength);

        mySpriteRenderer.color = Color.white;
    }

    private void Die()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, deathVFXDuration);

        Destroy(gameObject);
    }

}
