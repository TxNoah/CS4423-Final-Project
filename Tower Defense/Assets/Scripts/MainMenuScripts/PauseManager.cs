using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Change the key as needed
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Stop the time to pause the game
            // You can also add other pause functionalities like disabling scripts, showing UI, etc.
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1; // Resume the game
            // Add functionality to resume the game, such as enabling scripts, hiding UI, etc.
            Debug.Log("Game Resumed");
        }
    }
}
