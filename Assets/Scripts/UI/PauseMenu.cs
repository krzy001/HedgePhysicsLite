using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public string menuScreen;

    public static bool paused;

    // Initially the pause menu isnt active
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // if the player ever presses the escape key, change the state of the pause screen.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //when paused, ingame time pauses.
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    //When resumed ingame time is set to normal
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //go to main menu if player selects quit on the pause screen
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScreen);
    }
}
