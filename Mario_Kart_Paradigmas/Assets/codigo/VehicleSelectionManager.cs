using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleSelectionManager : MonoBehaviour
{
    public Button continueButton;
    private string selectedVehicle;

    void Start()
    {
        // Desactivar el botón "Continuar" al inicio
        continueButton.interactable = false;
    }

    public void SelectVehicle(string vehicleName)
    {
        // Guardar el vehículo seleccionado y activar el botón "Continuar"
        selectedVehicle = vehicleName;
        continueButton.interactable = true;

    }

    public void ContinueToMapSelection()
    {
        if (!string.IsNullOrEmpty(selectedVehicle))
        {
            MenuManager.Instance.SelectVehicle(selectedVehicle);
        }
    }

}
