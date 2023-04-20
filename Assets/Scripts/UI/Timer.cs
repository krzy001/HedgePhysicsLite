using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject FinishTrig;

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject MinuteBoxShadow;
    public GameObject SecondBox;
    public GameObject SecondBoxShadow;
    public GameObject MilliBox;
    public GameObject MilliBoxShadow;

    // Start is called before the first frame update
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
        MilliCount = -Time.deltaTime * 60;

        FinishTrig.SetActive(true);

    }

    // Update is called once per frame
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

        FinishTrig.SetActive(false);
    }
}
