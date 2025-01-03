using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //[SerializeField]
    //private VehicleController vehicleController;
    [SerializeField]
    private float speed = 10f;

    public void ModifySpeed(float multiplier, float duration)
    {
        StartCoroutine(ModifySpeedCoroutine(multiplier, duration));
    }
    

    private IEnumerator ModifySpeedCoroutine(float multiplier, float duration)
    {
        speed *= multiplier;
        yield return new WaitForSeconds(duration);
        speed /= multiplier;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        if (obstacle != null )
        {
            obstacle.OnTriggerEnter(Collider other);   
        }

    }*/

    void Update()
    {
        
    }
}
