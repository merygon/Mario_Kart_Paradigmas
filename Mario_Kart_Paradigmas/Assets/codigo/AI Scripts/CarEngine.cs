using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [SerializeField]
    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;


    public WheelCollider wheelfrontLeft;
    public WheelCollider wheelfrontRight;
    public WheelCollider wheelrearLeft;
    public WheelCollider wheelrearRight;

    public float maxSteerAngle = 45f; 
    public float maxMotorTorque = 200f; 
    public float nodeReachThreshold = 2f; 
    public float maxSpeed = 50f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        //MoveCarForward();
        Drive();
        CheckNodeDistance();
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle ;
        wheelfrontLeft.steerAngle = newSteer;
        wheelfrontRight.steerAngle = newSteer;
        Debug.Log("Applying steer: " + newSteer);
    }


    private void Drive()
    {
        // Aplicar fuerza del motor a las ruedas delanteras
        wheelfrontLeft.motorTorque = maxMotorTorque;
        wheelfrontRight.motorTorque = maxMotorTorque;

        Debug.Log("Motor torque applied: " + maxMotorTorque);
    }

    private void CheckNodeDistance()
    {
        // Verificar la distancia al nodo actual
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < nodeReachThreshold)
        {
            // Pasar al siguiente nodo
            currentNode++;
            if (currentNode >= nodes.Count)
            {
                currentNode = 0; // Reiniciar la ruta si se alcanzó el final
            }
        }
    }

    private void MoveCarForward()
    {
        Vector3 forwardForce = transform.forward * 10f; // Ajusta la fuerza según sea necesario
        GetComponent<Rigidbody>().AddForce(forwardForce);
        Debug.Log("Applying forward force: " + forwardForce);
    }

    private void LimitSpeed()
    {
        // Limitar la velocidad máxima del coche
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }


}
