using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public string nextLevel;

    //When the player hits the goalpost, save the gamedata values and load the next level
    private void OnTriggerEnter()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(nextLevel);
    }
}
