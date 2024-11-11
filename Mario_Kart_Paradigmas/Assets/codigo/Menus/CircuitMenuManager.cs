using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircuitMenuManager : MenuManager
{
    public void SelectCircuit(string map)
    {
        GameData.Instance.selectedMap = map;
        Debug.Log($"Map selected: {GameData.Instance.selectedMap}");
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedCharacter) &&
            !string.IsNullOrEmpty(GameData.Instance.selectedVehicle) &&
            !string.IsNullOrEmpty(GameData.Instance.selectedMap))
        {
            GameData.Instance.raceStarted = true;
            ChangeMenu("RaceScene");
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje, un vehículo y un circuito antes de empezar.");
        }
    }
}
