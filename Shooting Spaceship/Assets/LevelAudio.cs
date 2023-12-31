using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
    [Header("------------ Audio Sources ------------")]
    [SerializeField] AudioSource musicSource;
    [Header("------------ Audio Clips ------------")]
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}
