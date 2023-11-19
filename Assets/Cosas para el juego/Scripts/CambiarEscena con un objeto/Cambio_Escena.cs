using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escena : MonoBehaviour
{
    public int Nivel;

    public string GetSceneName()
    {
        string level = "";  // Corregido: inicializar la variable level

        if (Nivel == 0)
        {
            level = "Menu";
        }
        else if (Nivel == 1)
        {
            level = "Basket_scene";  // Cambiado: ajustar el nombre de la escena
        }
        else if (Nivel == 2)
        {
            level = "MundoHamaca";  // Cambiado: ajustar el nombre de la escena
        }
        else if (Nivel == 3)
        {
            level = "Desition_Scene";  // Cambiado: ajustar el nombre de la escena
        }

        else if (Nivel == 4)
        {
            level = "Ir_al_cine";  // Cambiado: ajustar el nombre de la escena
        }

        return level;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(GetSceneName());
        }
    }
}
