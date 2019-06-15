using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] float defaultVolume = 0.75f;

    [SerializeField] Slider intensitySlider = null;
    [SerializeField] float defaultIntensity = 1f;

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
    }

    private void UpdateMusicVolume()
    {
        Debug.Log(musicPlayerObject.name);
        if (musicPlayerObject)
        {
            musicPlayerObject.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No music player found.");
        }
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
