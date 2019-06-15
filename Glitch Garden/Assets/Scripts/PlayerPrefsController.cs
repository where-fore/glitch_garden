using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    public static void SetMasterVolume(float newVolume)
    {
        if (newVolume >= MIN_VOLUME && newVolume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, newVolume);
        }
        else
        {
            Debug.LogError("Volume definition out of range.");
        }
    }
    public static float GetMasterVolume() {return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);}


    const string MASTER_INTENSITY_KEY = "intensity";
    const float MIN_INTENSITY = 0.5f;
    const float MAX_INTENSITY = 1.5f;
    public static void SetIntensity(float newIntensity)
    {
        if (newIntensity >= MIN_INTENSITY && newIntensity <= MAX_INTENSITY)
        {
            PlayerPrefs.SetFloat(MASTER_INTENSITY_KEY, newIntensity);
        }
        else
        {
            Debug.LogError("Intensity definition out of range.");
        }
    }
    public static float GetIntensity() {return PlayerPrefs.GetFloat(MASTER_INTENSITY_KEY);}
    
}
