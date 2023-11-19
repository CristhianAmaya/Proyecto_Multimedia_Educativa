using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoDelay : MonoBehaviour
{
    public AudioClip[] delayedAudioClips; // Cambiado a un arreglo de AudioClip
    private AudioSource audioSource;
    private int currentClipIndex = 0; // Índice para rastrear el audio actual
    public float delayBetweenClips = 3f; // Nuevo intervalo de tiempo entre clips

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Asegúrate de tener un AudioSource en el objeto actual
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró un componente AudioSource adjunto a este objeto.");
        }

        // Invoca la función PlayDelayed después de 5 segundos.
        Invoke("PlayDelayed", delayBetweenClips);
    }

    void PlayDelayed()
    {
        // Reproduce el sonido después de 5 segundos.
        if (delayedAudioClips != null && audioSource != null && currentClipIndex < delayedAudioClips.Length)
        {
            // Configura el AudioClip actual
            audioSource.clip = delayedAudioClips[currentClipIndex];

            // Reproduce el AudioClip actual
            audioSource.Play();

            // Incrementa el índice para el siguiente AudioClip
            currentClipIndex++;

            // Invoca la función PlayDelayed nuevamente después del intervalo entre clips
            Invoke("PlayDelayed", delayBetweenClips);
        }
    }
}
