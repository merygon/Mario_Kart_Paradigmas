using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenuManager : MonoBehaviour
{
    public void SelectCharacter(string character)
    {
        GameData.Instance.selectedCharacter = character;
        Debug.Log($"Character selected: {character}");
    }

    public void GoToVehicleMenu()
    {
        if (!string.IsNullOrEmpty(GameData.Instance.selectedCharacter))
        {
            SceneManager.LoadScene("MenuCoches");
        }
        else
        {
            Debug.LogWarning("Selecciona un personaje antes de continuar.");
        }
    }
}

