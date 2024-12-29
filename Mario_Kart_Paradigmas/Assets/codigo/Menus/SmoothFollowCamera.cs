
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El coche que la cámara seguirá
    public Vector3 offset = new Vector3(0, 0, 0); // Ajusta la posición relativa de la cámara
    public float followSpeed = 15f; // Velocidad de seguimiento
    public float rotationSpeed = 10f; // Velocidad de rotación para seguir al coche

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target no asignado a la cámara.");
            return;
        }

        // Movimiento suave con Slerp en lugar de Lerp
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Slerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Rotación suave con Slerp
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}

