using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string selectedCharacter = "";
    public string selectedVehicle = "";
    public string selectedMap = "";
    public bool raceStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre escenas
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }
}


