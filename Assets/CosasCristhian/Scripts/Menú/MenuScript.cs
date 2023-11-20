using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayButton(int Nivel)
    {
        PlayerPrefs.SetInt("Nivel", Nivel);
        if(Nivel == 0){
            SceneManager.LoadScene("Desition_Scene");
        }
        if(Nivel == 1){
            SceneManager.LoadScene("Controls");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Nivel == 2){
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
}
