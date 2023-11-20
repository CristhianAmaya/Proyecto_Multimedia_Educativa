using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_score_collider : MonoBehaviour
{
    public General_Script general_Script;
    public ParticleSystem winEffect;
    public AudioClip collisionSound; // Agrega un AudioClip desde el Inspector
    private AudioSource audioSource;

    public enum score_target
    {
        score1 = 2,
    };
    public score_target value_target;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Si no hay un AudioSource adjunto, muestra un mensaje de advertencia.
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró un componente AudioSource adjunto a este objeto.");
        }

        // Configura el AudioClip para reproducir.
        if (audioSource != null)
        {
            audioSource.clip = collisionSound;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Interactable")
        {
            general_Script.AddScore((int)value_target);
            winEffect.Play();

            // Reproduce el sonido al colisionar si hay un AudioSource y un AudioClip.
            if (audioSource != null && collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}