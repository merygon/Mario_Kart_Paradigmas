using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;               // El coche que queremos seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Offset detrás del coche
    public float smoothSpeed = 0.125f;     // Velocidad de suavizado

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target no asignado en SmoothCameraFollow.");
            return;
        }

        // Calcula la posición deseada de la cámara respecto al coche
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        // Interpola suavemente entre la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rota la cámara para mirar en la misma dirección que el coche
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeed);
    }
}
