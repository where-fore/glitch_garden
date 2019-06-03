using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    private Color notSelectedColor = new Color32(65, 65, 65, 255);
    private Color selectedColor = new Color32(255, 255, 255, 255);

    [SerializeField] GameObject defenderToSpawn = null;
    public GameObject correspondingDefender() {return defenderToSpawn;}
        
    private bool selected = false;
    private List<DefenderButton> allButtons = new List<DefenderButton>();
    private SpriteRenderer mySpriteRenderer = null;

    private void Start()
    {
        allButtons.AddRange(FindObjectsOfType<DefenderButton>());
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (selected)
        {
            mySpriteRenderer.color = selectedColor;
        }
        else
        {
            mySpriteRenderer.color = notSelectedColor;
        }
    }

    private void OnMouseDown()
    {
        SelectButton();
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
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }
}
