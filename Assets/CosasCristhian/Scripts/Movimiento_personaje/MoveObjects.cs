using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public Vector3 puntoInicial;
    public Vector3 puntoFinal;
    public float velocidad = 2.0f;
    private float tiempo = 0.0f;
    private bool yendoHaciaFinal = true;

    void Update()
    {
        // Incrementa o decrementa el tiempo basado en la velocidad y el tiempo del frame
        tiempo += (yendoHaciaFinal ? 1 : -1) * velocidad * Time.deltaTime;

        // Normaliza el tiempo para obtener un valor entre 0 y 1
        tiempo = Mathf.Clamp01(tiempo);

        // Utiliza la función de interpolación lineal para calcular la posición intermedia
        Vector3 nuevaPosicion = InterpolarEntrePuntos(puntoInicial, puntoFinal, tiempo);

        // Asigna la nueva posición al objeto
        transform.position = nuevaPosicion;

        // Verifica si el objeto ha llegado al punto final o al punto inicial
        if (tiempo >= 1.0f || tiempo <= 0.0f)
        {
            // Cambia la dirección
            yendoHaciaFinal = !yendoHaciaFinal;
        }
    }

    // Función de interpolación lineal entre dos puntos
    Vector3 InterpolarEntrePuntos(Vector3 inicio, Vector3 fin, float t)
    {
        return inicio + (fin - inicio) * t;
    }
}

