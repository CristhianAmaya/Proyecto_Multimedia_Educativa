using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver_controles : MonoBehaviour
{
    public GameObject controllate;
    private bool selecr = false;
    private float lastPressTime = 0f;
    private float cooldown = 1f;

    public void MenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Time.time - lastPressTime > cooldown)
        {
            lastPressTime = Time.time;

            if (selecr == false)
            {
                controllate.SetActive(true);
                selecr = true;
            }
            else if (selecr == true)
            {
                controllate.SetActive(false);
                selecr = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MenuControl();
    }
}
