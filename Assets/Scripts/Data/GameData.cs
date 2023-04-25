using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    //All the gamedata that needs to be carried over repeat playthroughs.
    public int lives;

    //Times split up into three to be displayed ingame correctly
    public int OpenLevelMinutes;
    public int OpenLevelSeconds;
    public float OpenLevelMilli;

    public int LinearLevelMinutes;
    public int LinearLevelSeconds;
    public float LinearLevelMilli;

    //Default values for new games.
    public GameData()
    {
        this.lives = 3;
        this.OpenLevelMinutes = 99;
        this.OpenLevelSeconds = 0;
        this.OpenLevelMilli = 0;
        this.LinearLevelMinutes = 99;
        this.LinearLevelSeconds = 0;
        this.LinearLevelMilli = 0;
    }
}
