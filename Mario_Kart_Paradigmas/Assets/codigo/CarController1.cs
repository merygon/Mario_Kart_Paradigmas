using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController1 : MonoBehaviour
{
    public float motorForce = 50f; // Reduce este valor para una velocidad más baja
    public float steeringForce = 10f; // Ajusta la dirección para que sea menos sensible
    public float brakeForce = 2000f;

    private float currentSteeringAngle;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // Baja el centro de masa para mayor estabilidad
    }

    void Update()
    {
        // Captura de entrada para el acelerador y el frenado
        float acceleration = Input.GetAxis("Vertical") * motorForce;
        float steering = Input.GetAxis("Horizontal") * steeringForce;

        ApplySteering(steering);
        ApplyMotorForce(acceleration);

        // Frenado si se presiona la tecla de espacio
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyBrakes();
        }
    }

    private void ApplyMotorForce(float acceleration)
    {
        // Aplica la fuerza de motor en las ruedas traseras, con un límite de velocidad
        float maxSpeed = 10f; // Límite de velocidad en unidades de Unity
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
        }
    }

    private void ApplySteering(float steering)
    {
        // Calcula el ángulo de dirección y aplica rotación
        currentSteeringAngle = steering;
        transform.Rotate(0, currentSteeringAngle * Time.deltaTime, 0);
    }

    private void ApplyBrakes()
    {
        // Aplica una fuerza en sentido contrario para frenar
        rb.AddForce(-rb.velocity * brakeForce * Time.deltaTime, ForceMode.Acceleration);
    }
}
