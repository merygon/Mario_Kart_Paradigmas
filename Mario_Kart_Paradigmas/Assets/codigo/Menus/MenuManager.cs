using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsPanel; // Referencia al panel de controles
    private bool isControlsPanelVisible = false; // Estado del panel
    public void ChangeMenu(string menuName)
    {
        Debug.Log($"Attempting to change to menu: {menuName}");
        SceneManager.LoadScene(menuName);
    }
    public void ToggleControls()
    {
        // Alternar la visibilidad del panel de controles
        isControlsPanelVisible = !isControlsPanelVisible;
        controlsPanel.SetActive(isControlsPanelVisible);
    }
    public void ExitGame()
    {
        Debug.Log("Exiting the game..."); // Logs for debugging purposes
        Application.Quit(); // Exits the application

        // For testing in the Unity Editor (this won't work in a built application)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
