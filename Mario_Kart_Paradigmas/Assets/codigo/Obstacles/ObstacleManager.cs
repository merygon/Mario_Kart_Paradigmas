using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        factory = new ObstacleFactory();

        factory.CreateObstacle("boost", new Vector3(0, 1, 5));
        factory.CreateObstacle("scene", new Vector3(5, 1, 10));
        factory.CreateObstacle("slider", new Vector3(-5, 1, 15));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
