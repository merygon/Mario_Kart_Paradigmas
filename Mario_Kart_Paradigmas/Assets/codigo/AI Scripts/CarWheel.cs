using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public WheelCollider target;
    private Vector3 wheelPos = new Vector3();   
    private Quaternion wheelRotation = new Quaternion();

    // Update is called once per frame
    void Update()
    {
        target.GetWorldPose(out wheelPos, out wheelRotation);
        transform.position = wheelPos;
        transform.rotation = wheelRotation;
    }
}
