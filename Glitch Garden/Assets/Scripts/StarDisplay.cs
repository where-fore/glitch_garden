using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;
    public int GetStarCount() {return stars;}
    public bool EnoughStarsFor(int cost) {return (stars >= cost);}

    private TextMeshProUGUI myTextComponent = null;


    void Start()
    {
        myTextComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        myTextComponent.text = stars.ToString();
    }


    public void SpendStars(int amount)
    {
        if (EnoughStarsFor(amount))
        {
            stars -= amount;
        }

    }

    public void AddStars(int amount)
    {
        stars += amount;
    }
}
