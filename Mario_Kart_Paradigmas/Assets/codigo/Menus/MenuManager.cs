using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public void ChangeMenu(string menuName)
    {
        Debug.Log($"Attempting to change to menu: {menuName}");
        SceneManager.LoadScene(menuName);
    }
}
