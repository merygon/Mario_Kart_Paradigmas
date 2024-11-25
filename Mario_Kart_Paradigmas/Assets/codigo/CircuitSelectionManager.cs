using UnityEngine;
using UnityEngine.UI;

public class CircuitSelectionManager : MonoBehaviour
{
    public Button startButton; // Botón "Empezar" para iniciar la carrera
    private string selectedMap; // Variable para almacenar el circuito seleccionado

    void Start()
    {
        // Desactivar el botón "Empezar" al inicio
        startButton.interactable = false;
    }

    public void SelectMap(string mapName)
    {
        // Guardar el circuito seleccionado y activar el botón "Empezar"
        selectedMap = mapName;
        startButton.interactable = true;
        Debug.Log($"Map selected: {selectedMap}");
    }

    public void StartRace()
    {
        if (!string.IsNullOrEmpty(selectedMap))
        {
            Debug.Log("Starting race with map: " + selectedMap);
            MenuManager.Instance.ChangeMenu("RaceScene");
        }
        else
        {
            Debug.LogWarning("No map selected, cannot start race.");
        }
    }
}

