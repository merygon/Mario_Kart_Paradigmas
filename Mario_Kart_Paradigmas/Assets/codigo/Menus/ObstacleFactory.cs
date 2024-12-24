using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory 
{
    public GameObject CreateObstacle(string type, Vector3 position)
    {
        GameObject obstacle = null;
        switch (type)
        {
            case "boost":
                obstacle = new GameObject("BoostObstacle");
                obstacle.AddComponent<BoostObstacle>();
                break;
            case "scene":
                obstacle = new GameObject("ScebeObstacle");
                obstacle.AddComponent<SceneObstacle>();
                break;
            case "slider":
                obstacle = new GameObject("SliderObstacle");
                obstacle.AddComponent<SliderObstacle>();
                break;

        }

        if (obstacle != null)
        {
            obstacle.transform.position = position;
            obstacle.AddComponent<BoxCollider>();

        }

        return obstacle;
    }
}
