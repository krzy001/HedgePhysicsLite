using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface between DataPersistenceManager and certain objects that need access to gamedata values.
public interface IDataPersistence
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);
}
