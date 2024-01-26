using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    //Changes the volume of the music based on the slider value
    public void ChangeVolume()
    {
        musicSource.volume = slider.value;
    }
}
