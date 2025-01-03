using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    //void OnPlayerCollision(PlayerScript player);
    void OnTriggerEnter(Collider other);
}
