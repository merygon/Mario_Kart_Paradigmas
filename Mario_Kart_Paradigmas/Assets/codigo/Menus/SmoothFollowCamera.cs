
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El coche que la c�mara seguir�
    public Vector3 offset = new Vector3(0, 0, 0); // Ajusta la posici�n relativa de la c�mara
    public float followSpeed = 15f; // Velocidad de seguimiento
    public float rotationSpeed = 10f; // Velocidad de rotaci�n para seguir al coche

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target no asignado a la c�mara.");
            return;
        }

        // Movimiento suave con Slerp en lugar de Lerp
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Slerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Rotaci�n suave con Slerp
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}

