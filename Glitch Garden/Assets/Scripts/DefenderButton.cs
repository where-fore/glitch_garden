using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    private Color notSelectedColor = new Color32(65, 65, 65, 255);
    private Color selectedColor = new Color32(255, 255, 255, 255);

    [SerializeField] Defender defenderToSpawn = null;
    [SerializeField] TextMeshProUGUI costObject = null;

    private List<DefenderButton> allButtons = new List<DefenderButton>();
    private SpriteRenderer mySpriteRenderer = null;

    private DefenderSpawner defenderSpawner = null;

    private void Start()
    {
        allButtons.AddRange(FindObjectsOfType<DefenderButton>());
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        labelButtonWithCost();
    }
    private void OnMouseDown()
    {
        SelectButton();
    }
    private void labelButtonWithCost()
    {
        costObject.text = defenderToSpawn.GetStarCost().ToString();
    }

    private void SelectButton()
    {
        foreach (DefenderButton button in allButtons)
        {
            button.Deselect();
        }
        
        this.Select();
    }

    public void Select()
    {
        mySpriteRenderer.color = selectedColor;
        defenderSpawner.SetDefenderToSpawn(defenderToSpawn);
    }

    public void Deselect()
    {
        mySpriteRenderer.color = notSelectedColor;
    }
}
