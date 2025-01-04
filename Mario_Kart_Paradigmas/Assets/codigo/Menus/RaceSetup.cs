using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    public Camera mainCamera; // Cámara principal de la escena

    void Start()
    {
        if (GameData.Instance.selectedMap == "RaceScene")
        {
            SetupRaceMode();
        }
        else
        {
            SetupTimeTrialMode();
        }
    }

    private void SetupRaceMode()
    {
        // Obtener todos los coches en la escena
        GameObject[] allCars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject car in allCars)
        {
            // Asegurar que todos los coches tengan el tag correcto
            if (car.tag != "Car")
            {
                Debug.LogWarning($"El coche {car.name} no tiene el tag 'Car'. Corrigiendo...");
                car.tag = "Car";
            }
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

                // Desactivar IA para el coche seleccionado
                CarEngine carEngine = car.GetComponent<CarEngine>();
                if (carEngine != null)
                {
                    carEngine.enabled = false;
                }
                foreach (CarWheel wheel in car.GetComponentsInChildren<CarWheel>())
                { 
                    wheel.enabled = false; 
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
                CarEngine carEngine = car.GetComponent<CarEngine>();
                if (carEngine != null)
                {
                    carEngine.enabled = true;
                }
                else
                {
                    Debug.LogError($"CarEngine no encontrado en el coche: {car.name}");
                }
                foreach (CarWheel wheel in car.GetComponentsInChildren<CarWheel>())
                {
                    wheel.enabled = true;
                }
            }
        }
    }

    private void SetupTimeTrialMode()
    {
        Debug.Log("Configurando el modo contrarreloj");

        // Desactivar todos los coches excepto el seleccionado
        GameObject[] allCars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject car in allCars)
        {
            if (car.name == GameData.Instance.selectedVehicle)
            {
                car.SetActive(true);

                // Habilitar VehicleController y asignar la cámara
                VehicleController carController = car.GetComponent<VehicleController>();
                if (carController != null)
                {
                    carController.enabled = true;
                }

                CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
                if (cameraFollow != null)
                {
                    cameraFollow.target = car.transform;
                }
                car.tag = "Car";

            }
            else
            {
                car.SetActive(false); // Desactivar coches no seleccionados
            }
        }
    }
}

