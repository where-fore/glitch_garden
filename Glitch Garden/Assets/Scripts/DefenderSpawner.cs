﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenderToSpawnObject = null;
    private void OnMouseDown()
    {
        SpawnDefender(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 mousePosInWorldGrid = SnapToGrid(mousePosInWorld);

        return mousePosInWorldGrid;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snappedX = Mathf.RoundToInt(rawWorldPos.x);
        float snappedY = Mathf.RoundToInt(rawWorldPos.y);
        
        return new Vector2(snappedX, snappedY);
    }

    private void SpawnDefender(Vector2 positionToSpawn)
    {
       GameObject newDefender = Instantiate(defenderToSpawnObject, positionToSpawn, Quaternion.identity); //as GameObject
    }
}
