using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour, IDataPersistence
{
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;

    //Split both times into three to be displayed correctly.
    public int OpenMinuteSaved;
    public int OpenSecondSaved;
    public float OpenMilliSaved;
    public int LinearMinuteSaved;
    public int LinearSecondSaved;
    public float LinearMilliSaved;

    public GameObject OpenMinuteBox;
    public GameObject OpenSecondBox;
    public GameObject OpenMilliBox;
    public GameObject LinearMinuteBox;
    public GameObject LinearSecondBox;
    public GameObject LinearMilliBox;

    //Set the toggle values to what the actual values are currently.
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }

        //Load the gamedata for the times to be displayed.
        DataPersistenceManager.instance.LoadGame();
    }

    //retieve the values on the save file and save them onto this object to be displayed.
    public void LoadData(GameData data)
    {
        this.OpenMinuteSaved = data.OpenLevelMinutes;
        this.OpenSecondSaved = data.OpenLevelSeconds;
        this.OpenMilliSaved = data.OpenLevelMilli;

        this.LinearMinuteSaved = data.LinearLevelMinutes;
        this.LinearSecondSaved = data.LinearLevelSeconds;
        this.LinearMilliSaved = data.LinearLevelMilli;

    }

    //nothing to save.
    public void SaveData(ref GameData data)
    {
        return;
    }

    //Display the text correctly
    public void Update()
    {
        
        if (OpenMinuteSaved < 10)
        {
            OpenMinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + OpenMinuteSaved + ":";
        }
        else
        {
            OpenMinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = OpenMinuteSaved + ":";
        }
        if (OpenSecondSaved < 10)
        {
            OpenSecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + OpenSecondSaved + ":";
        }
        else
        {
            OpenSecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = OpenSecondSaved + ":";
        }
        if (OpenMilliSaved < 10)
        {
            OpenMilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + OpenMilliSaved.ToString("F0"); //round the value to the nearest whole number.
        }
        else
        {
            OpenMilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = OpenMilliSaved.ToString("F0");
        }


        if (LinearMinuteSaved < 10)
        {
            LinearMinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + LinearMinuteSaved + ":";
        }
        else
        {
            LinearMinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = LinearMinuteSaved + ":";
        }
        if (LinearSecondSaved < 10)
        {
            LinearSecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + LinearSecondSaved + ":";
        }
        else
        {
            LinearSecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = LinearSecondSaved + ":";
        }
        if (LinearMilliSaved < 10)
        {
            LinearMilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + LinearMilliSaved.ToString("F0");
        }
        else
        {
            LinearMilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = LinearMilliSaved.ToString("F0");
        }
}

    //Graphics settings are applied to whatever the user selected with the toggles.
    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenToggle.isOn;

        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
