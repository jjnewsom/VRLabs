using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Procedure : MonoBehaviour
{
    public GameObject RightAnch;
    public GameObject LeftAnch;
    public GameObject weight2;
    public GameObject weight4;

    private float rangeRight2;
    private float rangeLeft2;
    private float rangeRight4;
    private float rangeLeft4;

    private string stopper;
    private string pump;
    private string flowrate;

    public StopperSnap stoppersnap;
    public Push_Button pushedButton;
    public FlowrateReader flowratereeader;
    public Text Warning;


    // Update is called once per frame
    void Update()
    {
        rangeRight2 = Vector3.Distance(RightAnch.transform.position, weight2.transform.position);
        rangeRight4 = Vector3.Distance(RightAnch.transform.position, weight4.transform.position);

        rangeLeft2 = Vector3.Distance(LeftAnch.transform.position, weight2.transform.position);
        rangeLeft4 = Vector3.Distance(LeftAnch.transform.position, weight4.transform.position);

        if(stoppersnap.stopperplaced == false)
        {
            stopper = "Place Stopper\n";
        }
        else
        {
            stopper = "";
        }

        if (pushedButton.pushed == false)
        {
            pump = "Turn On Pump\n";
        }
        else
        {
            pump = "";
        }

        if(flowratereeader.gpmpercent <= 2)
        {
            flowrate = "Increase Flowrate\n";
        }
        else
        {
            flowrate = "";
        }

        string display = "Please....\n" + stopper + pump + flowrate;

        if(rangeLeft2 <= 0.25 || rangeRight2 <= 0.25 || rangeLeft4 <= 0.25 || rangeRight4 <= 0.25)
        {
            if (stoppersnap.stopperplaced == false || flowratereeader.gpmpercent <= 2 || pushedButton.pushed == false)
            {
                weight2.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                weight4.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                Warning.text = display;
            }
            else
            {
                Warning.text = "";
                weight2.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
                weight4.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
            }
        }
        else
        {
            Warning.text = "";
            weight2.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
            weight4.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
        }
    }
}
