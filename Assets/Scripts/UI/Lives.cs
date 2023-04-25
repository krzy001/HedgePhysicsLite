using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int livesCount;

    //Two different boxes the give the text a "shadow" effect.
    public GameObject livesBox;
    public GameObject livesBoxShadow;

    // Start with 3 lives displayed
    void Start()
    {
        livesBox.GetComponent<TMPro.TextMeshProUGUI>().text = "3";
        livesBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "3";

        livesCount = 3;
    }

    // Update the text to the current value of player lives.
    void Update()
    {
        livesBox.GetComponent<TMPro.TextMeshProUGUI>().text = livesCount + "";
        livesBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = livesCount + "";
    }
}
