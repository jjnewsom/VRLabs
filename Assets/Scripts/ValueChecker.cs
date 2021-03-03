using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChecker : MonoBehaviour
{
    public Text stopper;
    public Text w1;
    public Text w2;
    public Text button;
    public Text flow;

    public bool stop;
    public bool w1snap;
    public bool w2snap;
    public bool buttonon;
    public double gpmpercent;

    // Update is called once per frame
    void Update()
    {
        stop = GameObject.Find("Stopper_Snap").GetComponent<StopperSnap>().stopperplaced; ;
        w1snap = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        w2snap = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        buttonon = GameObject.Find("Cylinder").GetComponent<Push_Button>().pushed;
        gpmpercent = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().gpmpercent;
        stopper.text = "Stopper" + stop.ToString();
        w1.text = "weight1" + w1snap.ToString();
        w2.text = "weight2" + w2snap.ToString();
        button.text = "Button" + buttonon.ToString();

    }
}
