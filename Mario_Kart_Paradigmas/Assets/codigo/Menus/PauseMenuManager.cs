using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Reference to the Pause Menu Panel
    public GameObject pauseButton; // Reference to the Pause Button

    private bool isPaused = false;

    void Start()
    {
        // Ensure the menu is hidden at the start
        pauseMenuPanel.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false); // Hide the pause button
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true); // Show the pause button
    }

    public void GoToFinalScene()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused before changing scenes
        SceneManager.LoadScene("FinalScene");
    }
}
