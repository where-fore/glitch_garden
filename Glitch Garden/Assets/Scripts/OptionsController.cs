using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] float defaultVolume = 0.75f;
    [SerializeField] TextMeshProUGUI volumeNumeralDisplay = null;

    [SerializeField] Slider intensitySlider = null;
    [SerializeField] float defaultIntensity = 1f;
    [SerializeField] TextMeshProUGUI intensityNumeralDisplay = null;

    private MusicPlayer musicPlayerObject = null;

    void Start()
    {
        musicPlayerObject = FindObjectOfType<MusicPlayer>();

        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        intensitySlider.value = PlayerPrefsController.GetIntensity();
    }

    void Update()
    {
        UpdateMusicVolume();
        UpdateNumeralDisplay();
    }

    private void UpdateMusicVolume()
    {
        if (musicPlayerObject)
        {
            musicPlayerObject.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No music player found. Did you start from splash?");
        }
    }

    private void UpdateNumeralDisplay()
    {
        volumeNumeralDisplay.text = System.Math.Round(volumeSlider.value, 2).ToString();
        intensityNumeralDisplay.text = System.Math.Round(intensitySlider.value, 2).ToString();
    }

    public void SaveAndExit()
    {
        SceneLoader sceneLoaderObject = FindObjectOfType<SceneLoader>();
        
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetIntensity(intensitySlider.value);

        sceneLoaderObject.LoadMainMenu(0f);
    }

    public void ResetToDefaults()
    {
        volumeSlider.value = defaultVolume;
        intensitySlider.value = defaultIntensity;
    }
}
