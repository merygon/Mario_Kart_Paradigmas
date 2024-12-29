using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleMenuManager : MonoBehaviour
{
    public void SelectVehicle(string vehicle)
    {
        GameData.Instance.selectedVehicle = vehicle;
        Debug.Log($"Vehicle selected: {vehicle}");
    }

    public void GoToCircuitMenu()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedVehicle))
        {
            SceneManager.LoadScene("MenuCircuito");
        }
        else
        {
            Debug.LogWarning("Selecciona un vehículo antes de continuar.");
        }
    }
}



