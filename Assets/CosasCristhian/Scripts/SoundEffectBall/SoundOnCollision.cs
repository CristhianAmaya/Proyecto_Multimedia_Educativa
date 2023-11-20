using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioClip collisionSound; // Agrega un AudioClip desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Asegúrate de tener un AudioSource en el objeto actual
        audioSource = GetComponent<AudioSource>();
        // Si no hay un AudioSource adjunto, muestra un mensaje de advertencia.
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró un componente AudioSource adjunto a este objeto.");
        }

        // Configura el AudioClip para reproducir.
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con un objeto que tiene el tag "Dribling"
        if (collision.gameObject.CompareTag("Dribling") && collisionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
