using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float movementSpeedMultiplier = 1f;
    [SerializeField] private float rotationSpeedMultiplier = 1f;
    [SerializeField] private bool fireToTheRight = true;
    private Vector2 firingDirection = new Vector2(0,0);

    private void Start()
    {
        firingDirection = Vector2.right;

        if (!fireToTheRight)
        {
            firingDirection = Vector2.left;
        }
    }

    private void Update()
    {
        transform.Translate(firingDirection * movementSpeedMultiplier * Time.deltaTime);

        transform.Rotate(Time.deltaTime * rotationSpeedMultiplier, 0, 0);
    }
}
