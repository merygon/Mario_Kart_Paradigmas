using UnityEngine;

public class ExitButtonManager : MonoBehaviour
{
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
