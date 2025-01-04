using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BoostObstacle : MonoBehaviour, IObstacle
{
    private float cooldownTime = 1f; // Tiempo de espera para evitar m�ltiples activaciones
    private float lastcollisionTime = 0f; // Marca de tiempo de la �ltima activaci�n

    public void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning($"Objeto colisionado: {other.name}, Tag: {other.tag}");
        
        VehicleController car = other.GetComponent<VehicleController>();
        if (car != null)
        {
         
            if (Time.time - lastcollisionTime >= cooldownTime)
            {
                lastcollisionTime = Time.time; 

                RaceUIManager uiManager = FindObjectOfType<RaceUIManager>();
                if (uiManager != null)
                {
                    // Aplicar el boost
                    car.ModifySpeed(1000f,15f); // Aumenta la velocidad
                    Debug.LogWarning($"Boost activado para: {car.name}");
                }
            }
            else
            {
                Debug.LogWarning("Colisi�n ignorada debido al cooldown.");
            }
        }
    }
}


