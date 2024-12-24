using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [SerializeField]
    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;
    //public float steerAngle = 40;
    public float maxSteerAngle = 44;
    public WheelCollider wheelfrontLeft;
    public WheelCollider wheelfrontRight;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ApplySteer();
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle ;
        wheelfrontLeft.steerAngle = newSteer;
        wheelfrontRight.steerAngle = newSteer;
    }



}
