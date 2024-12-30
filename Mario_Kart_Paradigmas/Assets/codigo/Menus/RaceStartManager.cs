using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaceStartManager : MonoBehaviour
{
    public GameObject redLight1; // Semáforo 1
    public GameObject redLight2; // Semáforo 2
    public GameObject redLight3; // Semáforo 3

    private bool raceStarted = false;

    void Start()
    {
        // Pausar el juego al inicio
        Time.timeScale = 0f;
        StartCoroutine(StartRaceSequence());
    }

    IEnumerator StartRaceSequence()
    {
        // Esperar 2 segundos y apagar el primer semáforo
        yield return new WaitForSecondsRealtime(2f);
        redLight1.SetActive(false);

        // Esperar 1 segundo y apagar el segundo semáforo
        yield return new WaitForSecondsRealtime(1f);
        redLight2.SetActive(false);

        // Esperar 1 segundo y apagar el tercer semáforo
        yield return new WaitForSecondsRealtime(1f);
        redLight3.SetActive(false);

        // Iniciar la carrera (reanudar el tiempo y activar controles)
        Time.timeScale = 1f;
        raceStarted = true;
    }
}

