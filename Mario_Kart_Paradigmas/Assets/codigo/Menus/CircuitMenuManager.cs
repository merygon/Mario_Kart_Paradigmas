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

            // Cargar la escena según el circuito seleccionado
            string selectedMap = GameData.Instance.selectedMap;

            Debug.Log($"Loading scene: {selectedMap}");
            SceneManager.LoadScene(selectedMap); // Usa el nombre de la escena almacenada en selectedMap
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje, un vehículo y un circuito antes de empezar la carrera.");
        }
    }
}
