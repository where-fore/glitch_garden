using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderToSpawnObject = null;

    private StarDisplay starDisplayObject = null;

    private void Start()
    {
        starDisplayObject = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        if (defenderToSpawnObject)
        {
            AttemptToPlaceDefenderAt(GetMousePosition());
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 positionToSpawn)
    {
        int defenderCost = defenderToSpawnObject.GetStarCost();
        
        if (starDisplayObject.EnoughStarsFor(defenderCost))
        {
            starDisplayObject.SpendStars(defenderCost);

            SpawnDefender(positionToSpawn);
        }
        else
        {
            starDisplayObject.FlashRed();
        }

    }

    public void SetDefenderToSpawn(Defender newDefender)
    {
        defenderToSpawnObject = newDefender;
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
        if (defenderToSpawnObject)
        {
            Defender newDefender = Instantiate(defenderToSpawnObject, positionToSpawn, Quaternion.identity); //as Defender
        }
    }
}
