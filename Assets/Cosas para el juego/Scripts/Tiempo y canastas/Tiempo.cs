using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public int timer = 60; // Cambiado a 60 segundos
    public TextMeshPro textoTimer;

    // Momento en el que se inició el temporizador
    private float tiempoInicio;

    void Start()
    {
        tiempoInicio = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoTranscurrido = Time.realtimeSinceStartup - tiempoInicio;

        if (timer > 0)
        {
            // Calcula el tiempo restante en función del tiempo transcurrido
            timer = Mathf.Max(0, Mathf.RoundToInt(60 - tiempoTranscurrido));
            ActualizarTextoTimer();
        }
        else
        {
            timer = 0;
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
}