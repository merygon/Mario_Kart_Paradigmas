using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostObstacle : MonoBehaviour, IObstacle
{
    public void OnPlayerCollision(PlayerScript player)
    {
        player.ModifySpeed(10f, 10f); // increases speed x10 during 10 seconds
        Debug.Log("Using a boost");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with boost");
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                OnPlayerCollision(player);
            }
        }
    }

}
