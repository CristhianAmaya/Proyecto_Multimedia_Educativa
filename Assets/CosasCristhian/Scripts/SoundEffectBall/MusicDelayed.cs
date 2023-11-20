using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDelayed : MonoBehaviour
{
    public AudioClip delayedAudioClip; // Agrega un AudioClip desde el Inspector
    private AudioSource audioSource;
    public float seconds;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Asegúrate de tener un AudioSource en el objeto actual
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró un componente AudioSource adjunto a este objeto.");
        }

        // Configura el AudioClip para reproducir.
        audioSource.clip = delayedAudioClip;

        // Invoca la función PlayDelayed después de 5 segundos.
        Invoke("PlayDelayed", seconds);
    }

    void PlayDelayed()
    {
        // Reproduce el sonido después de 5 segundos.
        if (delayedAudioClip != null && audioSource != null)
        {
            audioSource.Play();
        }
    }
}
