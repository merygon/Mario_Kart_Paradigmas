using UnityEngine;

public class LapCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que cruza la meta es un coche
        // CarController car = other.GetComponent<CarController>(); // Aseg�rate de que tu coche tenga este script // -------

        //if (car != null)
        //{
        // car.IncrementLap(); // Llama a una funci�n en el coche para incrementar su contador de vueltas
        //}
    }
}
