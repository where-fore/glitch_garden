using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLostCanvasBehaviour : MonoBehaviour
{
    private string buttonChildObjectStringReference = "Buttons";
    public void BringUpButtons()
    {
        transform.Find(buttonChildObjectStringReference).gameObject.SetActive(true);
    }
}
