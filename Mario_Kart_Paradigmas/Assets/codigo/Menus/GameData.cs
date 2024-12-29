using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string selectedCharacter = "";
    public string selectedVehicle = "";
    public string selectedMap = "";
    public bool raceStarted = false;

    public int playerPosition = 0; // Posición del jugador
    public List<string> otherCharacters = new List<string>(); // Lista de los otros personajes

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
