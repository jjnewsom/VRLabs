using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowRate : MonoBehaviour
{
    public Text FlowRateText;
    private bool PumpState;
    public float flowrate;
    private float flowratepercent;
    private int SpeedSet;
    private int maxflow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PumpState = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        float rotationangle = GameObject.Find("wheelV2").GetComponent<WheelTurning>().rottext;
        SpeedSet = GameObject.Find("Button (Speed)").GetComponent<SpeedButton>().SpeedState;

        flowratepercent = rotationangle * 100 / 1080;   //divide by max rotation 
        flowrate = flowratepercent * maxflow / 100;

        if (SpeedSet == 1150)
        {
            maxflow = 42;
        }
        else if (SpeedSet == 1750)
        {
            maxflow = 69;
        }

        if (PumpState == true)
        {
            FlowRateText.text = flowrate.ToString("0.#") + "GPM" + "\n" + flowratepercent.ToString("0.#") + " %";
        }
        else if (PumpState == false)
        {
            FlowRateText.text = "Off";
        }
    }
}
