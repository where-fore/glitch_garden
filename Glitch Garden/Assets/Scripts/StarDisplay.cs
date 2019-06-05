using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    private int stars = 1000;
    public int GetStarCount() {return stars;}
    public bool EnoughStarsFor(int cost) {return (stars >= cost);}

    private TextMeshProUGUI myTextComponent = null;
    private float colourFlashLength = 0.75f;
    private Color defaultColor = Color.white; //you can serialize this and then initialize in Start() if you like, but then in the editor the color is the default white. currently, it reads the color you have set in the editor and uses that.


    void Start()
    {
        myTextComponent = GetComponent<TextMeshProUGUI>();
        defaultColor = myTextComponent.color;
    }

    void Update()
    {
        myTextComponent.text = stars.ToString();

        FlashText();
    }

    private void FlashText()
    {

    }


    public void SpendStars(int amount)
    {
        if (EnoughStarsFor(amount))
        {
            stars -= amount;

            if (stars < 0)
            {
                Debug.Log("DEBUG: Somehow ended up with 0 stars after spending - StarDisplay.cs");
            }
        }

    }

    public void AddStars(int amount)
    {
        stars += amount;
    }

    public void FlashRed()
    {
        StartCoroutine(ActuallyFlashRed());
    }

    private IEnumerator ActuallyFlashRed()
    {
        Color redColor = Color.red;
        Color normalColor = defaultColor;

        if (myTextComponent.color != redColor)
        {
            myTextComponent.color = redColor;
            
            yield return new WaitForSeconds(colourFlashLength);

            myTextComponent.color = normalColor;
        }


    }
}
