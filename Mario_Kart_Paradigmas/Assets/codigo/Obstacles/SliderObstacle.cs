using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObstacle : MonoBehaviour, IObstacle
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Collision with slider");
            VehicleController vehicle = other.GetComponent<VehicleController>();
            if (vehicle != null)
            {
                vehicle.ModifySpeed(-3f, 3f);
            }
        }
    }
}