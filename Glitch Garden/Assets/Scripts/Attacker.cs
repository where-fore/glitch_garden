using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float currentSpeed = 0f;
    public void SetMovementSpeed(float newSpeed) {currentSpeed = newSpeed;}


    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

}
