using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio, float volume = 1f)
    {
        AudioSource.PlayOneShot(audio, volume);
    }
}
