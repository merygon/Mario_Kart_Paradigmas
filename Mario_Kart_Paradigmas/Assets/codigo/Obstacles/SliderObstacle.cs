using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObstacle : MonoBehaviour, IObstacle
{
    public void OnPlayerCollision(PlayerScript player)
    {
        player.ModifySpeed(-3f, 3f); // decreases speed x3 during 3 seconds
        Debug.Log("Using a slider");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with slider");
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                OnPlayerCollision(player);
            }
        }
    }
}