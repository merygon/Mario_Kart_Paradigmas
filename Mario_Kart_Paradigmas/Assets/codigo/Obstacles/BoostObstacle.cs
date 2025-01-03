using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostObstacle : MonoBehaviour, IObstacle
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            VehicleController vehicle = other.GetComponent<VehicleController>();
            if (vehicle != null)
            {
                vehicle.ModifySpeed(10f, 10f);
            }
        }
    }

}
