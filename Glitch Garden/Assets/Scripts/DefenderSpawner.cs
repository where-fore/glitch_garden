using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderToSpawnObject = null;

    private StarDisplay starDisplayObject = null;

    private List<Defender> allDefenders = new List<Defender>();

    private void Start()
    {
        starDisplayObject = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        Vector2 mousePos = GetMousePosition();
        if (defenderToSpawnObject)
        {
            if (!OverlappingDefender(mousePos))
            {
                AttemptToPlaceDefenderAt(mousePos);
            }

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

    private bool OverlappingDefender(Vector2 positionToCheck)
    {
        foreach (Defender defender in allDefenders)
        {
            if (!defender) {continue;}
            
            Vector2 defenderPosition = new Vector2(defender.transform.position.x, defender.transform.position.y);
            if (positionToCheck == defenderPosition)
            {
                return true;
            }
        }

        //if you made it this far...
        return false;

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
            allDefenders.Add(newDefender);
            newDefender.transform.parent = this.transform;
        }
    }
}
