using UnityEngine;

public class CarController : MonoBehaviour
{
    public int currentLap = 0;
    public float lapTime = 0f;
    public int totalLaps = 3; // Número máximo de vueltas para la carrera

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
        // Si la carrera ya terminó, no hacemos nada
        if (raceFinished)
            return;

        currentLap++;

        // Guardar el tiempo de la vuelta si deseas mantener un historial de vueltas
        Debug.Log($"Coche {gameObject.name} completó la vuelta {currentLap} en {lapTime} segundos.");

        // Reinicia el tiempo de vuelta para la próxima
        lapTime = 0f;

        // Comprueba si ha terminado la carrera
        if (currentLap >= totalLaps)
        {
            raceFinished = true;
            Debug.Log($"Coche {gameObject.name} ha terminado la carrera.");
            // Aquí puedes añadir la lógica para agregar al coche a una lista de ganadores
        }
    }
}
