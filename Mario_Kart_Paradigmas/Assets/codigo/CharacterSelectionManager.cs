using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public Button continueButton;
    private string selectedCharacter;

    void Start()
    {
        // Desactivar el bot�n "Continuar" al inicio
        continueButton.interactable = false;
    }

    public void SelectCharacter(string characterName)
    {
        // Guardar el personaje seleccionado y activar el bot�n "Continuar"
        selectedCharacter = characterName;
        continueButton.interactable = true;
    }

    public void ContinueToVehicleSelection()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            MenuManager.Instance.SelectCharacter(selectedCharacter);
        }
    }
}

