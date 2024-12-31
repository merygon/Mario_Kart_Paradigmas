using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RaceUIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI lapCounterText;
    public TextMeshProUGUI lapTimesText; // Texto para los tiempos por vuelta
    public RectTransform needle;
    public float maxSpeed = 200f;

    private float currentTime = 0f;
    private float timePast = 0f;
    public int currentLap = 0;
    public int totalLaps = 3;
    public float currentSpeed = 0f;
    private List<float> lapTimes = new List<float>(); // Lista para guardar los tiempos de las vueltas

    private bool isTimeTrial = false; // Si es contrarreloj
    private float timeLimit = 300f; // Límite de 5 minutos en contrarreloj

    void Start()
    {
        isTimeTrial = GameData.Instance.selectedMap != "RaceScene";

        // Inicialización de textos
        timeText.text = "Time: 0.00";

        if (!isTimeTrial)
        {
            lapCounterText.text = $"{currentLap}/{totalLaps}";
        }
        else
        {
            lapCounterText.text = $"Laps: {currentLap}"; // Contar vueltas en contrarreloj
        }

        lapTimesText.text = ""; // Texto vacío al inicio
        SetNeedleRotation(0);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        timePast += Time.deltaTime;
        if (isTimeTrial)
        {
            float timeRemaining = Mathf.Clamp(timeLimit - timePast, 0, timeLimit);
            timeText.text = "Time Left: " + timeRemaining.ToString("F2");

            if (timeRemaining <= 0)
            {
                EndTimeTrial();
            }
        }
        else
        {
            timeText.text = "Time: " + currentTime.ToString("F2");
        }
    }

    public void UpdateSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(speed, 0, maxSpeed);
        SetNeedleRotation(currentSpeed);
    }

    public void UpdateLap()
    {
        lapTimes.Add(currentTime); // Guardar tiempo de la vuelta
        UpdateLapTimesText();

        if (isTimeTrial)
        {
            currentTime = 0f;
            currentLap++;
            lapCounterText.text = $"Laps: {currentLap}";
        }
        else
        {
            currentTime = 0f;

            currentLap++;
            lapCounterText.text = $"{currentLap}/{totalLaps}";

            if (currentLap >= 4)
            {
                Debug.Log("¡Carrera completada!");
                FinishRace();
            }
        }
    }

    private void UpdateLapTimesText()
    {
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
        SceneManager.LoadScene("FinalScene");
    }

    private void EndTimeTrial()
    {
        Debug.Log("Tiempo agotado. Fin del contrarreloj.");
        GameData.Instance.lapTimes = new List<float>(lapTimes); // Guardar los tiempos para la escena final
        SceneManager.LoadScene("FinalScene");
    }
}

