using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudio : MonoBehaviour
{

    [Header("------------ Audio Sources ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------ Audio Clips ------------")]
    public AudioClip background;
    public AudioClip shooting;
    public AudioClip explosion;

    // Start is called before the first frame update

    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlayShootingSound()
    {
        SFXSource.clip = shooting;
        SFXSource.Play();
    }
    public void PlayExplosionSound()
    {
        SFXSource.clip = explosion;
        SFXSource.Play();
    }
}
