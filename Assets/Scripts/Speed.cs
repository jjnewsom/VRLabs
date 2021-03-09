using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public Text SpeedText;
    private bool PumpState;
    private int SpeedState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PumpState = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        SpeedState = GameObject.Find("Button (Speed)").GetComponent<SpeedButton>().SpeedState;

        if (PumpState == true)
        {
            SpeedText.text = SpeedState.ToString();
        }
        else if (PumpState == false)
        {
            SpeedText.text = "Off";
        }
    }
}
