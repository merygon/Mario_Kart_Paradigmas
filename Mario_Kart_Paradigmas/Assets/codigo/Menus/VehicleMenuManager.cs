using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleMenuManager : MenuManager
{
    public void SelectVehicle(string vehicle)
    {
        GameData.Instance.selectedVehicle = vehicle;
        Debug.Log($"Vehicle selected: {GameData.Instance.selectedVehicle}");
    }

    public void GoToCircuitMenu()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedCharacter) && !string.IsNullOrEmpty(GameData.Instance.selectedVehicle))
        {
            ChangeMenu("MenuCircuito");
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje y un vehículo antes de continuar.");
        }
    }
}
