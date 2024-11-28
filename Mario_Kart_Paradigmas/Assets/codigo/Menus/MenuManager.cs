using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeMenu(string menuName)
    {
        Debug.Log($"Attempting to change to menu: {menuName}");
        SceneManager.LoadScene(menuName);
    }
}
