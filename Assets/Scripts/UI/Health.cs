using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int healthCount;

    //Two different boxes the give the text a "shadow" effect.
    public GameObject healthBox;
    public GameObject healthBoxShadow;

    //Start off with 100% health displayed.
    void Start()
    {
        healthBox.GetComponent<TMPro.TextMeshProUGUI>().text = "100%";
        healthBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "100%";

        healthCount = 100;
    }

    //Update the text to the current value of health
    void Update()
    {
        healthBox.GetComponent<TMPro.TextMeshProUGUI>().text = healthCount + "%";
        healthBoxShadow.GetComponent<TMPro.TextMeshProUGUI>().text = healthCount + "%";
    }
}
