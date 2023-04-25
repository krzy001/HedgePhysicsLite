using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, IDataPersistence
{

    public GameObject FinishTrig;

    public string LevelName;

    public int bestMinuteSaved;
    public int bestSecondSaved;
    public float bestMilliSaved;

    //Time split into three to be displayed correctly.
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    //Display split into two to create a shadow effect on the text.
    public GameObject MinuteBox;
    public GameObject MinuteBoxShadow;
    public GameObject SecondBox;
    public GameObject SecondBoxShadow;
    public GameObject MilliBox;
    public GameObject MilliBoxShadow;

    public BasePhysics Player;

    // Start with time as 0
    void Start()
    {
        MilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00";
        MilliBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00";
        SecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        SecondBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        MinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        MinuteBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";

        MinuteCount = 0;
        SecondCount = 0;
        MilliCount = -Time.deltaTime * 60; // MilliCount is equal to negative amount of time the game has been running. This will end up starting at 0 when the game continues.

        FinishTrig.SetActive(true);

    }

    //load the best level time saved depending on the current level
    public void LoadData(GameData data)
    {
        if (LevelName == "Open")
        {
            this.bestMinuteSaved = data.OpenLevelMinutes;
            this.bestSecondSaved = data.OpenLevelSeconds;
            this.bestMilliSaved = data.OpenLevelMilli;
        }

        if (LevelName == "Linear")
        {
            this.bestMinuteSaved = data.LinearLevelMinutes;
            this.bestSecondSaved = data.LinearLevelSeconds;
            this.bestMilliSaved = data.LinearLevelMilli;
        }
    }

    //Save the new time if its shorter than the time currently saved.
    //Only saves if the player was still alive when the scene ends. If the player's health reached 0, dont save the new time.
    public void SaveData(ref GameData data)
    {
        if (Player.health > 0)
        {
            if (MinuteCount < bestMinuteSaved)
            {
                SaveBestTime(ref data);
            }

            if (MinuteCount == bestMinuteSaved && SecondCount < bestSecondSaved)
            {
                SaveBestTime(ref data);
            }

            if (MinuteCount == bestMinuteSaved && SecondCount == bestSecondSaved && MilliCount < bestMilliSaved)
            {
                SaveBestTime(ref data);
            }
        }
    }

    private void SaveBestTime(ref GameData data)
    {
        if (LevelName == "Open")
        {
            data.OpenLevelMinutes = MinuteCount;
            data.OpenLevelSeconds = SecondCount;
            data.OpenLevelMilli = MilliCount;
        }

        if (LevelName == "Linear")
        {
            data.LinearLevelMinutes = MinuteCount;
            data.LinearLevelSeconds = SecondCount;
            data.LinearLevelMilli = MilliCount;
        }
    }

    // Display the timer correctly in the format "00:00:00".
    void Update()
    {
        if (FinishTrig)
        {
            MilliCount += Time.deltaTime * 60;
            MilliDisplay = MilliCount.ToString("F0");

            if (MilliCount <= 9)
            {
                MilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + MilliDisplay;
                MilliBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + MilliDisplay;
            }
            else
            {
                MilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "" + MilliDisplay;
                MilliBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "" + MilliDisplay;
            }

            if (MilliCount >= 60)
            {
                MilliCount = 0;
                SecondCount += 1;
            }

            if (SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount += 1;
            }
        }

        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + SecondCount + ":";
            SecondBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + SecondCount + ":";
        }
        else
        {
            SecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "" + SecondCount + ":";
            SecondBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "" + SecondCount + ":";
        }

        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + MinuteCount + ":";
            MinuteBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "" + MinuteCount + ":";
            MinuteBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "" + MinuteCount + ":";
        }



    }

    //Once the player reaches the finish, stop the timer and reset all timer values back to 0.
    void OnTriggerEnter()
    {
        FinishTrig.SetActive(false);
        
        MilliBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00";
        MilliBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00";
        SecondBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        SecondBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        MinuteBox.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";
        MinuteBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "00:";

        MinuteCount = 0;
        SecondCount = 0;
        MilliCount = -Time.deltaTime * 60;

    }
}
