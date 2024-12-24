using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObstacle : MonoBehaviour, IObstacle
{
    public void OnPlayerCollision(PlayerScript player)
    {
        player.ModifySpeed(-5f, 5f); // decreases speed x5 during 5 seconds
        Debug.Log("Using a monster");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with monster");
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                OnPlayerCollision(player);
            }
        }
    }

    private void Update()
    {
        // logic for the obstacle to appear randomly in the scene
        transform.position += new Vector3(Random.Range(-1f, -1f), 0, Random.Range(-1f, -1f)) * Time.deltaTime;

    }
}
