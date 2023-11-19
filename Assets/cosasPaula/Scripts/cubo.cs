using UnityEngine;

public class MovimientoHamaca : MonoBehaviour
{
    public float amplitud = 2.0f;
    public float frecuencia = 1.0f;
    public float velocidadRotacion = 50.0f;
    public float suavizado = 0.1f; // Ajusta el factor de suavizado

    private float tiempo;
    private Vector3 posicionObjetivo;

    void Update()
    {
        // Actualizar el tiempo basado en el tiempo transcurrido desde el último frame
        tiempo += Time.deltaTime;

        // Calcular la posición en el movimiento de la hamaca
        float x = Mathf.Sin(tiempo * frecuencia) * amplitud;
        float y = -Mathf.Abs(Mathf.Cos(tiempo * frecuencia) * amplitud);  // Negativo para el movimiento hacia abajo

        // Aplicar suavizado a las posiciones x e y
        x = Mathf.Lerp(transform.position.x, x, suavizado);
        y = Mathf.Lerp(transform.position.y, y, suavizado);

        // Almacenar la nueva posición en un vector para evitar problemas de acumulación
        posicionObjetivo = new Vector3(x, y, 0f);

        // Mover el objeto ajustando la posición
        transform.position = posicionObjetivo;

        // Calcular la inclinación en la dirección contraria al movimiento
        float inclinacion = Mathf.Sin(tiempo * frecuencia) * 20.0f;  // Puedes ajustar el factor de inclinación

        // Aplicar la inclinación
        transform.rotation = Quaternion.Euler(0f, 0f, inclinacion);

        // Eliminar la rotación adicional para evitar acumulación de rotación
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
