using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource myAudioSource = null;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetVolume(float newVolume)
    {
        myAudioSource.volume = newVolume;
    }
}
