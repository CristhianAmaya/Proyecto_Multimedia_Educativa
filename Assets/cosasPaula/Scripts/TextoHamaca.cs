using UnityEngine;

public class GestorTextoInfo : MonoBehaviour
{
    public GameObject textoPrefab;
    private GameObject textoInstanciado;
    public float distanciaActivacion = 5f;

    private bool enZona = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true;
            InstanciarTexto();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false;
            DestruirTexto();
        }
    }

    void InstanciarTexto()
    {
        if (textoInstanciado == null && enZona)
        {
            textoInstanciado = Instantiate(textoPrefab, transform.position, Quaternion.identity);
        }
    }

    void DestruirTexto()
    {
        if (textoInstanciado != null)
        {
            Destroy(textoInstanciado);
            textoInstanciado = null;
        }
    }
}
