using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObstacle : MonoBehaviour, IObstacle
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Collision with monster");
            VehicleController vehicle = other.GetComponent<VehicleController>();
            if (vehicle != null)
            {
                vehicle.ModifySpeed(-5f, 5f);
            }
        }
    }

    private void Update()
    {
        // logic for the obstacle to appear randomly in the scene
        transform.position += new Vector3(Random.Range(-1f, -1f), 0, Random.Range(-1f, -1f)) * Time.deltaTime;

    }
}
