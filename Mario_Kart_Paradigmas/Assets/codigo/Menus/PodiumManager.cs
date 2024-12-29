using System.Collections.Generic;
using UnityEngine;

public class PodiumManager : MonoBehaviour
{
    public Transform position1; // Transform del primer lugar
    public Transform position2; // Transform del segundo lugar
    public Transform position3; // Transform del tercer lugar

    public GameObject character1Prefab;
    public GameObject character2Prefab;
    public GameObject character3Prefab;

    void Start()
    {
        GameData gameData = GameData.Instance;
        if (gameData == null)
        {
            Debug.LogError("GameData no encontrado.");
            return;
        }

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
