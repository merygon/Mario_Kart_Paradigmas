using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectionManager : MonoBehaviour
{
    public Button startRaceButton;
    private string selectedMap;

    void Start()
    {
        // Desactivar el bot�n "Start Race" al inicio
        startRaceButton.interactable = false;
    }

    public void SelectMap(string mapName)
    {
        // Guardar el mapa seleccionado y activar el bot�n "Start Race"
        selectedMap = mapName;
        startRaceButton.interactable = true;

    }

    public void StartRace()
    {
        if (!string.IsNullOrEmpty(selectedMap))
        {
            MenuManager.Instance.SelectMap(selectedMap);
        }
    }

}

