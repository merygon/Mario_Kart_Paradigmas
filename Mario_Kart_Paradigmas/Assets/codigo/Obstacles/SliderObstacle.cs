using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObstacle : MonoBehaviour, IObstacle
{
    private float cooldownTime = 1f;
    private float lastCollisionTime = 0f;
    public void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning($"Objeto colisionado: {other.name}, Tag: {other.tag}");

        VehicleController vehicle = other.GetComponent<VehicleController>();
        if (vehicle != null)
        {
            if (Time.time - lastCollisionTime >= cooldownTime)
            {
                lastCollisionTime = Time.time;

                // Aplicar la penalización de velocidad
                vehicle.ModifySpeed(-3f, 3f);
                Debug.LogWarning($"SceneObstacle activado para: {vehicle.name}");
            }
            else
            {
                Debug.LogWarning("Colisión ignorada debido al cooldown.");
            }

        }
    }

}