using UnityEngine;

public class LapCounter : MonoBehaviour
{
    private float cooldownTime = 1f; // Tiempo de espera para evitar m�ltiples activaciones
    private float lastLapTime = 0f; // Marca de tiempo de la �ltima activaci�n

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que cruza es un coche
        VehicleController car = other.GetComponent<VehicleController>();
        if (car != null)
        {
            // Comprobar si el cooldown ha pasado
            if (Time.time - lastLapTime >= cooldownTime)
            {
                lastLapTime = Time.time; // Actualizar el tiempo de la �ltima vuelta

                RaceUIManager uiManager = FindObjectOfType<RaceUIManager>();
                if (uiManager != null)
                {
                    uiManager.UpdateLap(); // Incrementar el contador de vueltas
                }

                // Determinar la posici�n al cruzar la meta
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
            Debug.Log("Actualizando la posici�n del jugador...");
            // Actualizar posici�n del jugador en el podio
            gameData.playerPosition = 1; // Cambia seg�n tu l�gica de comparaci�n
        }
    }
}

