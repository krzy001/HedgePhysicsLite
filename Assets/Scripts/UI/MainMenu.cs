using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionsScreen;

    //When the player selects start, load the save file and the first level.
    public void StartGame()
    {
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene(firstLevel);
    }

    //when the player selects Menu, activate the menu screen to be displayed over the menu screen
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    //When the player selects close on the menu screen, deactivate the menu to display the main menu.
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    //quit the game if quit is selected.
    public void QuitGame()
    {
        Application.Quit();
    }
}
