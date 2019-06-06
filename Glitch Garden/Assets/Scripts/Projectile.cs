using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float movementSpeedMultiplier = 1f;
    [SerializeField] private float rotationSpeedMultiplier = 1f;
    [SerializeField] private bool rotateX = false;
    [SerializeField] private bool rotateY = false;
    [SerializeField] private bool rotateZ = false;
    [SerializeField] private bool fireToTheRight = true;
    private Vector2 firingDirection = new Vector2(0,0);

    private GameObject body = null;
    private string bodyChildStringReference = "Body";

    private void Start()
    {
        firingDirection = Vector2.right;

        if (!fireToTheRight)
        {
            firingDirection = Vector2.left;
        }

        body = transform.Find(bodyChildStringReference).gameObject;
    }

    private void Update()
    {
        transform.Translate(firingDirection * movementSpeedMultiplier * Time.deltaTime);


        if (rotateX)
        {
            body.transform.Rotate(Time.deltaTime * rotationSpeedMultiplier, 0, 0);
        }
        if (rotateY)
        {
            body.transform.Rotate(0, Time.deltaTime * rotationSpeedMultiplier, 0);
        }
        if (rotateZ)
        {
            body.transform.Rotate(0, 0, Time.deltaTime * rotationSpeedMultiplier);
        }
    }

}
