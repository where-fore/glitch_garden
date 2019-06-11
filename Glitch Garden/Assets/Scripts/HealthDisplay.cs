using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private Base baseObject = null;
    private int healthToDisplay = 50;

    private float colourFlashLength = 3f;
    private TextMeshProUGUI myTextComponent = null;
    private Color defaultColor = Color.white; //you can serialize this if you like, but then in the editor the color is the default white. currently, it reads the color you have set in the editor and uses that.

    void Start()
    {
        baseObject = FindObjectOfType<Base>();
        myTextComponent = GetComponent<TextMeshProUGUI>();
        defaultColor = myTextComponent.color;

        myTextComponent.text = baseObject.GetHealth().ToString();
    }

    public void UpdateText()
    {
        healthToDisplay = baseObject.GetHealth();
        if (healthToDisplay < 0)
        {
            healthToDisplay = 0;
        }

        myTextComponent.text = healthToDisplay.ToString();

        FlashRed();
    }

    private void FlashRed()
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
