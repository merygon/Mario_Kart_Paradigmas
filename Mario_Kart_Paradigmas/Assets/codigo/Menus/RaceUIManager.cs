using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RaceUIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI lapCounterText;
    public TextMeshProUGUI lapTimesText; // Para mostrar los tiempos de las vueltas
    public RectTransform needle;
    public float maxSpeed = 200f;

    private float currentTime = 0f;
    public int currentLap = 0;
    public int totalLaps = 3;
    public float currentSpeed = 0f;
    private List<float> lapTimes = new List<float>(); // Lista para guardar los tiempos de las vueltas

    void Start()
    {
        // Inicialización de textos y aguja
        timeText.text = "Time: 0.00";
        lapCounterText.text = $"{currentLap}/{totalLaps}";
        lapTimesText.text = ""; // Texto vacío al inicio
        SetNeedleRotation(0);
    }

    void Update()
    {
        // Incrementar tiempo de la vuelta actual
        currentTime += Time.deltaTime;
        timeText.text = "Time: " + currentTime.ToString("F2");
    }

    public void UpdateSpeed(float speed)
    {
        // Actualiza la velocidad y la aguja
        currentSpeed = Mathf.Clamp(speed, 0, maxSpeed);
        SetNeedleRotation(currentSpeed);
    }

    public void UpdateLap()
    {
        // Guardar el tiempo de la vuelta completada
        lapTimes.Add(currentTime);
        UpdateLapTimesText();

        // Reiniciar el tiempo para la nueva vuelta
        currentTime = 0f;

        // Incrementar el contador de vueltas
        currentLap++;
        lapCounterText.text = $"{currentLap}/{totalLaps}";

        // Comprobar si la carrera ha terminado
        if (currentLap >= 4)
        {
            Debug.Log("¡Carrera completada!");
            FinishRace(); // Llama al método para finalizar la carrera
        }
    }

    private void UpdateLapTimesText()
    {
        // Actualizar el texto del historial de tiempos de vueltas
        lapTimesText.text = "Lap Times:\n";
        for (int i = 0; i < lapTimes.Count; i++)
        {
            lapTimesText.text += $"Lap {i + 1}: {lapTimes[i]:F2}s\n";
        }
    }

    private void SetNeedleRotation(float speed)
    {
        float rotation = Mathf.Lerp(-220, 50, speed / maxSpeed);
        needle.localEulerAngles = new Vector3(0, 0, -rotation);
    }

    private void FinishRace()
    {
        // Lógica para finalizar la carrera
        SceneManager.LoadScene("FinalScene");
    }
}

