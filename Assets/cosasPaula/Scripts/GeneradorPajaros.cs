using UnityEngine;

public class GeneradorPajaros : MonoBehaviour
{
    public GameObject pajaroPrefab; // Asigna el prefab del pájaro desde el Inspector
    public int cantidadPajaros = 5; // Cantidad de pájaros a generar
    public float alturaMinima = 1f; // Altura mínima a la que pueden aparecer los pájaros
    public float alturaMaxima = 5f; // Altura máxima a la que pueden aparecer los pájaros
    public float velocidadMovimiento = 2f; // Velocidad de movimiento en el eje Z

    void Start()
    {
        GenerarPajaros();
    }

    void GenerarPajaros()
    {
        for (int i = 0; i < cantidadPajaros; i++)
        {
            // Genera una posición aleatoria en el espacio
            float alturaAleatoria = Random.Range(alturaMinima, alturaMaxima);
            Vector3 posicionAleatoria = new Vector3(Random.Range(-10f, 10f), alturaAleatoria, Random.Range(-10f, 10f));

            // Instancia el pájaro en la posición aleatoria
            GameObject pajaro = Instantiate(pajaroPrefab, posicionAleatoria, Quaternion.identity);

            // Asigna un script de movimiento al pájaro
            pajaro.AddComponent<MovimientoPajaro>().velocidad = velocidadMovimiento;
        }
    }
}

public class MovimientoPajaro : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        // Mueve el pájaro en el eje Z usando la función Sin para un movimiento oscilante
        transform.position += new Vector3(0f, 0f, Mathf.Sin(Time.time * velocidad) * Time.deltaTime);
    }
}
