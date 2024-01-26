using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
    [Header("------------ Audio Sources ------------")]
    [SerializeField] AudioSource musicSource;
    [Header("------------ Audio Clips ------------")]
    public AudioClip background;

    //Starts playing the background music
    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("Volume val");

        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}
