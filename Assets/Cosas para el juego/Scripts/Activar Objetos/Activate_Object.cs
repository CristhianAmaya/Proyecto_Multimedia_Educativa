using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Object : MonoBehaviour
{
    public List<GameObject> puertas;
    public float tiempo_deseado;
    private float tiempoTranscurrido = 0f; // Tiempo acumulado
    

    void Start()
    {
        foreach (GameObject puerta in puertas)
        {
            puerta.SetActive(false);
        }
    }

    public void PuertaControl()
    {
        // Actualizar el tiempo acumulado
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si ha pasado el tiempo deseado
        if (tiempoTranscurrido >= tiempo_deseado) // Puedes ajustar el valor según tus necesidades
        {
            foreach (GameObject puerta in puertas)
            {
                puerta.SetActive(true);
            }
        }

        Debug.Log(tiempoTranscurrido);
    }

    void Update()
    {
        PuertaControl();
    }
}
