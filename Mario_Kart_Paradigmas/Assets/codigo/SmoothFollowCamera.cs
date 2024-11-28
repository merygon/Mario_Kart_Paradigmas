using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;               // El coche que queremos seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Offset detr�s del coche
    public float smoothSpeed = 0.125f;     // Velocidad de suavizado

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target no asignado en SmoothCameraFollow.");
            return;
        }

        // Calcula la posici�n deseada de la c�mara respecto al coche
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        // Interpola suavemente entre la posici�n actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rota la c�mara para mirar en la misma direcci�n que el coche
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeed);
    }
}
