using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//This finction handles the gamedata

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    //if another instance of a data persistence manager already exists, make it this one.
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Extra Data Persistence Manager found");
        }
        instance = this;
    }

    //On start, go to file location where the save file will be.
    //Then save every object that has the IDataPersistence interface into a list
    //Then load the game data.

    private void Start()
    {
        //Application.persistentDataPath for Windows is under Users/*user*/AppData/LocalLow/DefaultCompany/HedgePhysicsLite
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    //Create new gamedata with default values
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    //Load the gamedata with values from the save file
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        //if a save file didnt exist, create new gamedata with default values.
        if (this.gameData == null)
        {
            NewGame();
        }

        //for every object with the IDataPersistence interface, load the data for their own respective values.
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(gameData);
        }

    }

    //Saves the gamedata into the save file
    public void SaveGame()
    {
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    //searches for all objects with the IDataPersistence extension and saves them into a list.
    //this is useful for all objects using the gamedata values, as they will be able to save/load the data
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
