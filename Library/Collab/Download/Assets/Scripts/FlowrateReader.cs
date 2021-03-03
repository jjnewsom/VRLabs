using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowrateReader : MonoBehaviour
{
    public GameObject ValveRot;
    public Text myText;
    private float rottext; //Rotation Angle
    public float gpmpercent;
    public double massflow;
    public double gpm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rottext = ValveRot.transform.localRotation.eulerAngles.x;
        gpmpercent = (rottext / 360) * 100;
        massflow = gpmpercent * 0.38 / 100;
        gpm = gpmpercent * 0.000385 / 100;
        myText.text = "Flowrate = " + gpm.ToString() + " gpm" + "\n" +gpmpercent.ToString("F0") + " %";
    }
}
