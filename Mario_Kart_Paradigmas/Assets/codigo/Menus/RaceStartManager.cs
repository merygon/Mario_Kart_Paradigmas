using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaceStartManager : MonoBehaviour
{
    public GameObject redLight1; // Sem�foro 1
    public GameObject redLight2; // Sem�foro 2
    public GameObject redLight3; // Sem�foro 3

    private bool raceStarted = false;

    void Start()
    {
        // Pausar el juego al inicio
        Time.timeScale = 0f;
        StartCoroutine(StartRaceSequence());
    }

    IEnumerator StartRaceSequence()
    {
        // Esperar 2 segundos y apagar el primer sem�foro
        yield return new WaitForSecondsRealtime(2f);
        redLight1.SetActive(false);

        // Esperar 1 segundo y apagar el segundo sem�foro
        yield return new WaitForSecondsRealtime(1f);
        redLight2.SetActive(false);

        // Esperar 1 segundo y apagar el tercer sem�foro
        yield return new WaitForSecondsRealtime(1f);
        redLight3.SetActive(false);

        // Iniciar la carrera (reanudar el tiempo y activar controles)
        Time.timeScale = 1f;
        raceStarted = true;
    }
}

