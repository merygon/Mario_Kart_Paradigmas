using UnityEngine;
using UnityEngine.SceneManagement;

public class CircuitMenuManager : MonoBehaviour
{
    public void SelectCircuit(string map)
    {
        GameData.Instance.selectedMap = map;
        Debug.Log($"Map selected: {map}");
    }

    public void StartRace()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedCharacter) &&
            !string.IsNullOrEmpty(GameData.Instance.selectedVehicle) &&
            !string.IsNullOrEmpty(GameData.Instance.selectedMap))
        {
            GameData.Instance.raceStarted = true;
            SceneManager.LoadScene("RaceScene");
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje, un vehículo y un circuito antes de empezar la carrera.");
        }
    }
}

