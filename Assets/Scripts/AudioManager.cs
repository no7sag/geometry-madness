using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
  public void ReproducirSonido(AudioClip audio)
  {
    AudioSource.PlayOneShot(audio);
  }
}
