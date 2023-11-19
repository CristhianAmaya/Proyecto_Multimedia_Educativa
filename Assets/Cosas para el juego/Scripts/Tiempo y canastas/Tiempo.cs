using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public int timer; // Cambiado a 180 segundos (3 minutos)
    private float tiempito;
    public TextMeshPro textoTimer;

    // Momento en el que se inició el temporizador
    private float tiempoInicio;

    // Variable para manejar si ya se reprodujo el sonido
    private bool sonidoReproducido = false;

    // AudioSource para reproducir el sonido
    private AudioSource audioSource;
    public AudioClip sonidoFin;

    void Start()
    {
        tiempoInicio = Time.realtimeSinceStartup;
        tiempito = timer;
        // Asegúrate de tener el componente AudioSource adjunto al objeto o asigna uno desde el Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        float tiempoTranscurrido = Time.realtimeSinceStartup - tiempoInicio;

        if (timer > 0)
        {
            // Calcula el tiempo restante en función del tiempo transcurrido
            timer = Mathf.Max(0, Mathf.RoundToInt(tiempito - tiempoTranscurrido)); // Cambiado a 180 segundos
            ActualizarTextoTimer();
        }
        else
        {
            timer = 0;
            if (!sonidoReproducido)
            {
                ReproducirSonidoFin();
                sonidoReproducido = true;
            }
            DetenerTemporizador();
        }
    }

    void ActualizarTextoTimer()
    {
        int minutos = timer / 60;
        int segundos = timer % 60;
        textoTimer.text = string.Format("Time: {0:00}:{1:00}", minutos, segundos);
    }

    void DetenerTemporizador()
    {
        Debug.Log("El temporizador ha llegado a cero. Deteniendo el temporizador.");
    }

    void ReproducirSonidoFin()
    {
        if (audioSource != null && sonidoFin != null)
        {
            audioSource.PlayOneShot(sonidoFin);
        }
    }
}

