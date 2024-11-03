using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string selectedCharacter;
    public string selectedVehicle;
    public string selectedMap;


    public void ChangeMenu(string NameMenu)
    {
        SceneManager.LoadScene(NameMenu);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MenuPersonajes");
    }

    public void SelectCharacter(string character)
    {
        selectedCharacter = character;
        SceneManager.LoadScene("MenuCoches");
    }

    public void SelectVehicle(string vehicle)
    {
        selectedVehicle = vehicle;
        SceneManager.LoadScene("MenuCircuito");
    }

    public void SelectMap(string map)
    {
        selectedMap = map;
        SceneManager.LoadScene("RaceScene"); // Cambia "RaceScene" por el nombre de la escena de tu carrera
    }
}

