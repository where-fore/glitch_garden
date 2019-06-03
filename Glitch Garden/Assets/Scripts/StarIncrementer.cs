using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarIncrementer : MonoBehaviour
{
    [SerializeField] private int defaultStarValue = 25;
    [SerializeField] private GameObject starVFX = null;

    private StarDisplay starDisplayObject = null;

    private void Start()
    {
        starDisplayObject = FindObjectOfType<StarDisplay>();
    }

    public void AddStars()
    {
        starDisplayObject.AddStars(defaultStarValue);
        PlayStarVFX();
    }

    private void PlayStarVFX()
    {
        GameObject starVFXObject = Instantiate(starVFX, transform.position, Quaternion.identity);
        Destroy(starVFXObject, starVFXObject.GetComponent<ParticleSystem>().main.duration);
    }
    
}
