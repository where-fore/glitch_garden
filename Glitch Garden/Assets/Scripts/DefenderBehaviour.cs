using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBehaviour : MonoBehaviour
{
    private GameObject shooter = null;
    private string shooterStringReference = "Shooter";
    void Start()
    {
        shooter = transform.Find(shooterStringReference).gameObject;
    }

}
