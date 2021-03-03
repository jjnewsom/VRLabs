using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int TotalWeight;
    private bool state1;
    private bool state2;
    private bool weightchanged;
    public float realtimer = 0f;
    public float formulatimer;
    public Text myTimer;
    public Text rTimer;
    private float massflowrate;
    private bool timer;
    public bool armrising;
    public bool armreset;
    public float armangle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        int target1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().snappedweight;

        state2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        int target2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().snappedweight;

        GameObject rotobject = GameObject.Find("MM_Box and Weight_Fix");
        rTimer.text = realtimer.ToString();
        bool ButtonOn = GameObject.Find("Cylinder").GetComponent<Push_Button>().pushed;
        bool stopperstate = GameObject.Find("Stopper_Snap").GetComponent<StopperSnap>().stopperplaced;
        double massflow = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().massflow;

        armangle = GameObject.Find("MM_Box and Weight_Fix").transform.eulerAngles.x;
        armrising = GameObject.Find("MM_Box and Weight_Fix").GetComponent<RotScript>().rotated;
        armreset = GameObject.Find("MM_Box and Weight_Fix").GetComponent<RotScript>().rotatedUp;

        TotalWeight = target1 + target2;
        formulatimer = realtimer * 4;

        StartCoroutine(WeightChangeCheck());

        if (state1 == false && state2 == false || armrising == false)
        {
            realtimer = 0f;
        }

        if (ButtonOn == true)
        {
            if (stopperstate == true)
            {
                if (massflow > 0)
                {
                    if (armrising == false )
                    {
                        myTimer.text = " ";
                    }
                    if (armangle > 0 && armrising == true && armreset == false)
                    {
                        realtimer += Time.deltaTime;
                        myTimer.text = "Weight = " + TotalWeight.ToString() + " kg" + "\n" + "Time = " + formulatimer.ToString("0.#") + " sec";
                    }
                    else if (armrising == true && armreset == true)
                    {
                        massflowrate = 3 * TotalWeight / formulatimer;
                        myTimer.text = "Weight = " + TotalWeight.ToString() + " kg" + "\n" + "Final Time = " + formulatimer.ToString("0.0") + " sec" + "\n" + "Mass Flowrate = " + massflowrate.ToString("0.0") + " kg/s";
                    }
                }
            }
        }
    }

    public IEnumerator WeightChangeCheck()
    {
        bool state1first = state1;
        bool state2first = state2;
        yield return new WaitForSeconds(0.083f);
        bool state1second = state1;
        bool state2second = state2;

        if (state1first != state1second || state2first != state2second)
        {
            realtimer = 0f;
        }
    }
}
