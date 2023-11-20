using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image imgSelector;
    public Slider sliderBar;
    public void ChangePickableBallColor(bool isSelect)
    {
        if(isSelect)
        {
            imgSelector.color = Color.green;
        }
        else
        {
           imgSelector.color = Color.white; 
        }
    }

    public void OcultarCursor(bool ocultar)
    {
        imgSelector.enabled = !ocultar;
    }

    public void ActivarSlider(bool activar)
    {
        sliderBar.gameObject.SetActive(activar);
    }

    public void SetValueBar(float vld)
    {
        sliderBar.value = vld;
    }
}
