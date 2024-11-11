using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenuManager : MenuManager
{

    public void SelectCharacter(string character)
    {
        GameData.Instance.selectedCharacter = character;
        Debug.Log($"Character selected: {GameData.Instance.selectedCharacter}");
    }

    public void GoToVehicleMenu()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedCharacter))
        {
            ChangeMenu("MenuCoches");
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje antes de continuar.");
        }
    }
}
