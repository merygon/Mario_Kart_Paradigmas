using UnityEngine;

public class CarController : MonoBehaviour
{
    public int currentLap = 0;
    public float lapTime = 0f;
    public int totalLaps = 3; // N�mero m�ximo de vueltas para la carrera

    private bool raceFinished = false;

    void Update()
    {
        // Incrementa el tiempo de vuelta si la carrera no ha terminado
        if (!raceFinished)
        {
            lapTime += Time.deltaTime;
        }
    }

    public void IncrementLap()
    {
        // Si la carrera ya termin�, no hacemos nada
        if (raceFinished)
            return;

        currentLap++;

        // Guardar el tiempo de la vuelta si deseas mantener un historial de vueltas
        Debug.Log($"Coche {gameObject.name} complet� la vuelta {currentLap} en {lapTime} segundos.");

        // Reinicia el tiempo de vuelta para la pr�xima
        lapTime = 0f;

        // Comprueba si ha terminado la carrera
        if (currentLap >= totalLaps)
        {
            raceFinished = true;
            Debug.Log($"Coche {gameObject.name} ha terminado la carrera.");
            // Aqu� puedes a�adir la l�gica para agregar al coche a una lista de ganadores
        }
    }
}
