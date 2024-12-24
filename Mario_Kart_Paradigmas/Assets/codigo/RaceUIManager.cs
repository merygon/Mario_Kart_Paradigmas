/*using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceUIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI lapCounterText; // Texto del contador de vueltas
    public RectTransform needle;
    public float maxSpeed = 200f;

    private float currentTime = 0f;
    private int currentLap = 1;
    private int totalLaps = 3; // Número total de vueltas
    private float currentSpeed = 0f;

    void Start()
    {
        // Valores iniciales para los textos y la aguja
        timeText.text = "Time: 0.00";
        UpdateLapCounter();
        SetNeedleRotation(0); // Posición inicial de la aguja en 0 de velocidad
    }

    void Update()
    {
        // Incrementa el tiempo y actualiza el texto
        currentTime += Time.deltaTime;
        timeText.text = "Time: " + currentTime.ToString("F2");

        // Simulación de cambio de velocidad para probar la aguja
        currentSpeed = Mathf.PingPong(Time.time * 50, maxSpeed);
        UpdateSpeed(currentSpeed);

        // Actualiza la aguja de velocidad
        SetNeedleRotation(currentSpeed);
    }

    public void UpdateSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(speed, 0, maxSpeed);
    }

    public void UpdateLap(int lap)
    {
        currentLap = lap;
        UpdateLapCounter();
    }

    private void UpdateLapCounter()
    {
        lapCounterText.text = $"{currentLap}/{totalLaps}";
    }

    private void SetNeedleRotation(float speed)
    {
        float rotation = Mathf.Lerp(-220, 50, speed / maxSpeed);
        needle.localEulerAngles = new Vector3(0, 0, -rotation);
    }
}*/
