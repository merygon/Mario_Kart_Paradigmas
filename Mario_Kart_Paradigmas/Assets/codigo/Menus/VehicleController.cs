using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentBrakeForce;
    private bool isBreaking;

    // Settings
    [SerializeField] public float motorForce = 60000f; // Aumentado para m�s velocidad
    [SerializeField] public float brakeForce = 5000f;
    [SerializeField] public float maxSteerAngle = 40f;

    // Wheel Colliders
    [SerializeField] public WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] public WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] public Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] public Transform rearLeftWheelTransform, rearRightWheelTransform;

    private RaceUIManager uiManager;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.7f, 0); // Ajustar centro de masa
        rb.drag = 0.02f; // Reducido para menos resistencia al movimiento
        rb.angularDrag = 1.0f;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        // Ajustar la fricci�n de las ruedas para mejorar la aceleraci�n
        AdjustWheelFriction(frontLeftWheelCollider, 1.2f, 1.6f);
        AdjustWheelFriction(frontRightWheelCollider, 1.2f, 1.6f);
        AdjustWheelFriction(rearLeftWheelCollider, 1.4f, 2.0f);
        AdjustWheelFriction(rearRightWheelCollider, 1.4f, 2.0f);

        // Encuentra el RaceUIManager
        uiManager = FindObjectOfType<RaceUIManager>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        float speed = rb.velocity.magnitude * 3.6f; // Convertir m/s a km/h
        if (speed < 400f) // Limitar la velocidad m�xima
        {
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce;
        }
        else
        {
            rearLeftWheelCollider.motorTorque = 0f;
            rearRightWheelCollider.motorTorque = 0f;
        }

        currentBrakeForce = isBreaking ? brakeForce : 0f;
        ApplyBreaking();

        // Actualiza la velocidad en RaceUIManager para aguja 
        if (uiManager != null)
        {
            uiManager.UpdateSpeed(speed);
        }
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce * 0.7f;
        frontRightWheelCollider.brakeTorque = currentBrakeForce * 0.7f;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        // Obtener la velocidad actual en km/h
        float speed = rb.velocity.magnitude * 3.6f;

        // Escalar el �ngulo de giro seg�n la velocidad, pero sin reducirlo demasiado
        float speedFactor = Mathf.Clamp(1 - (speed / 300f), 0.6f, 1f); // Al menos 50% del �ngulo m�ximo
        float adjustedSteerAngle = maxSteerAngle * speedFactor;

        // Calcular el �ngulo de giro basado en la entrada del jugador
        currentSteerAngle = adjustedSteerAngle * horizontalInput;

        // Asignar el �ngulo a los WheelColliders
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }



    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    private void AdjustWheelFriction(WheelCollider wheel, float forwardStiffness, float sidewaysStiffness)
    {
        WheelFrictionCurve forwardFriction = wheel.forwardFriction;
        WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;

        forwardFriction.stiffness = forwardStiffness;
        sidewaysFriction.stiffness = sidewaysStiffness;

        wheel.forwardFriction = forwardFriction;
        wheel.sidewaysFriction = sidewaysFriction;
    }
}
