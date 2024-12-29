using UnityEngine;

public class LapCounter : MonoBehaviour
{
    private float cooldownTime = 1f; // Tiempo de espera para evitar múltiples activaciones
    private float lastLapTime = 0f; // Marca de tiempo de la última activación

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que cruza es un coche
        VehicleController car = other.GetComponent<VehicleController>();
        if (car != null)
        {
            // Comprobar si el cooldown ha pasado
            if (Time.time - lastLapTime >= cooldownTime)
            {
                lastLapTime = Time.time; // Actualizar el tiempo de la última vuelta

                RaceUIManager uiManager = FindObjectOfType<RaceUIManager>();
                if (uiManager != null)
                {
                    uiManager.UpdateLap(); // Incrementar el contador de vueltas
                }

                // Determinar la posición al cruzar la meta
                DeterminePlayerPosition(car);
            }
            else
            {
                Debug.Log("Cruce de meta ignorado debido al cooldown.");
            }
        }
    }

    private void DeterminePlayerPosition(VehicleController playerCar)
    {
        GameData gameData = GameData.Instance;
        if (gameData == null) return;

        // Comprobar si el coche actual es el seleccionado
        if (gameData.selectedVehicle == playerCar.gameObject.name)
        {
            Debug.Log("Actualizando la posición del jugador...");
            // Actualizar posición del jugador en el podio
            gameData.playerPosition = 1; // Cambia según tu lógica de comparación
        }
    }
}

