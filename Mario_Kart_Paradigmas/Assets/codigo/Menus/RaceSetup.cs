using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    public Camera mainCamera; // Cámara principal de la escena

    void Start()
    {
        // Obtener todos los coches en la escena
        GameObject[] allCars = GameObject.FindGameObjectsWithTag("Car");

        // Recorrer todos los coches
        foreach (GameObject car in allCars)
        {
            // Verificar si el nombre del coche coincide con el seleccionado
            if (car.name == GameData.Instance.selectedVehicle)
            {
                Debug.Log($"Coche seleccionado encontrado: {car.name}");

                // Habilitar VehicleController en el coche seleccionado
                VehicleController carController = car.GetComponent<VehicleController>();
                if (carController != null)
                {
                    carController.enabled = true;
                }
                else
                {
                    Debug.LogError($"VehicleController no encontrado en el coche: {car.name}");
                }

                // Asignar la cámara al coche seleccionado
                CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
                if (cameraFollow != null)
                {
                    cameraFollow.target = car.transform;
                }
                else
                {
                    Debug.LogWarning("CameraFollow no encontrado en la cámara principal.");
                }
            }
            else
            {
                // Deshabilitar VehicleController en los coches no seleccionados
                VehicleController carController = car.GetComponent<VehicleController>();
                if (carController != null)
                {
                    carController.enabled = false;
                }
            }
        }
    }
}
