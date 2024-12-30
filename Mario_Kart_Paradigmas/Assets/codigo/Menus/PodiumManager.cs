using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PodiumManager : MonoBehaviour
{
    public Transform position1; // Transform del primer lugar
    public Transform position2; // Transform del segundo lugar
    public Transform position3; // Transform del tercer lugar

    public GameObject character1Prefab;
    public GameObject character2Prefab;
    public GameObject character3Prefab;

    public GameObject timeTrialPanel; // Panel para mostrar los tiempos en contrarreloj
    public TextMeshProUGUI timeTrialText; // Texto para los tiempos en el panel
    public TextMeshProUGUI sortedLapTimesText; // Nuevo texto para las vueltas ordenadas

    void Start()
    {
        GameData gameData = GameData.Instance;

        if (gameData == null)
        {
            Debug.LogError("GameData no encontrado.");
            return;
        }

        if (gameData.selectedMap == "RaceScene")
        {
            SetupRacePodium(gameData);
        }
        else
        {
            SetupTimeTrialResults(gameData);
        }
    }

    private void SetupRacePodium(GameData gameData)
    {
        timeTrialPanel.SetActive(false);

        // Colocar al jugador en su posición
        Transform playerPosition = GetPositionTransform(gameData.playerPosition);
        GameObject playerCharacter = GetCharacterPrefab(gameData.selectedCharacter);
        if (playerPosition != null && playerCharacter != null)
        {
            Instantiate(playerCharacter, playerPosition.position, Quaternion.identity);
        }

        // Colocar los otros personajes en las posiciones restantes
        PlaceOtherCharacters(gameData);
    }

    private void SetupTimeTrialResults(GameData gameData)
    {
        timeTrialPanel.SetActive(true);

        timeTrialText.text = "Lap Times:\n";

        if (gameData.lapTimes != null && gameData.lapTimes.Count > 0)
        {
            for (int i = 0; i < gameData.lapTimes.Count; i++)
            {
                timeTrialText.text += $"Lap {i + 1}: {gameData.lapTimes[i]:F2}s\n";
            }

            // Mostrar las vueltas ordenadas
            ShowSortedLapTimes(gameData.lapTimes);
        }
        else
        {
            timeTrialText.text = "No lap times recorded.";
            sortedLapTimesText.text = "No lap times to sort.";
        }
    }

    private void ShowSortedLapTimes(List<float> lapTimes)
    {
        // Ordenar los tiempos de vuelta de menor a mayor
        List<float> sortedTimes = new List<float>(lapTimes);
        sortedTimes.Sort();

        // Mostrar los tiempos ordenados en el nuevo texto
        sortedLapTimesText.text = "Sorted Lap Times:\n";
        for (int i = 0; i < sortedTimes.Count; i++)
        {
            int lapIndex = lapTimes.IndexOf(sortedTimes[i]) + 1; // Obtener el índice de la vuelta original
            sortedLapTimesText.text += $"Lap {lapIndex}: {sortedTimes[i]:F2}s\n";
        }
    }

    private Transform GetPositionTransform(int position)
    {
        return position switch
        {
            1 => position1,
            2 => position2,
            3 => position3,
            _ => null,
        };
    }

    private GameObject GetCharacterPrefab(string characterName)
    {
        return characterName switch
        {
            "Catherine" => character1Prefab,
            "Paperman" => character2Prefab,
            "Robert" => character3Prefab,
            _ => null,
        };
    }

    private void PlaceOtherCharacters(GameData gameData)
    {
        var remainingPositions = new List<Transform> { position1, position2, position3 };
        remainingPositions.Remove(GetPositionTransform(gameData.playerPosition));

        var otherCharacters = new List<string> { "Catherine", "Paperman", "Robert" };
        otherCharacters.Remove(gameData.selectedCharacter);

        for (int i = 0; i < remainingPositions.Count; i++)
        {
            GameObject characterPrefab = GetCharacterPrefab(otherCharacters[i]);
            if (characterPrefab != null)
            {
                Instantiate(characterPrefab, remainingPositions[i].position, Quaternion.identity);
            }
        }
    }
}

