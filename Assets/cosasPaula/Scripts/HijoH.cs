using UnityEngine;

public class AdjuntarAHamaca : MonoBehaviour
{
    void Update()
    {
        // Verifica si se presionó la tecla "T"
        if (Input.GetKeyDown(KeyCode.T))
        {
            AttachPlayersToHammock();
        }
    }

    void AttachPlayersToHammock()
    {
        // Busca el objeto con la etiqueta "Hamaca"
        GameObject[] hamacas = GameObject.FindGameObjectsWithTag("Hamaca");

        // Verifica si se encontró al menos una hamaca
        if (hamacas.Length > 0)
        {
            // Busca el objeto con la etiqueta "Player"
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            // Verifica si se encontró al menos un jugador
            if (players.Length > 0)
            {
                // Haz que cada objeto Player sea hijo de la primera Hamaca encontrada
                foreach (GameObject player in players)
                {
                    // Guarda la posición de la hamaca
                    Vector3 hamacaPosition = hamacas[0].transform.position;

                    // Haz que el jugador sea hijo de la hamaca
                    player.transform.parent = hamacas[0].transform;

                    // Asigna la posición de la hamaca al jugador
                    player.transform.position = hamacaPosition;

                    // Cambia la rotación del jugador en el eje X a -90 grados
                    player.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                }

                Debug.Log("Los objetos Player ahora son hijos de la Hamaca, tienen la misma posición y la rotación en X es -90 grados.");
            }
            else
            {
                Debug.LogError("No se encontró ningún objeto con la etiqueta 'Player'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'Hamaca'.");
        }
    }
}
