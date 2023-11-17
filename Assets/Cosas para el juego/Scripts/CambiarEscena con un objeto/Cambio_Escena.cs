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
            level = "Controls";  // Cambiado: ajustar el nombre de la escena
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
