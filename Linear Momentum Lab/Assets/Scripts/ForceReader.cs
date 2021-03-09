using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceReader : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    private float rottext; //Rotation Angle
    private float gpm; //GPM
    public double forcetext;
    private double Q; //Float rate in ft^3/s
    private double v; //ft/s
    private double A; //area
    private float b; //angle value
    public Text targetsign; //checks target angle
    public int degrees;

    //private float p; //density (slugs/ft^3)
    //private float ctheta; //angle

    // Start is called before the first frame update
    void Start()
    {


        //float ctheta = 90;
    }

    // Update is called once per frame
    void Update()
    {
        int OnOff = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;

        if (targetsign.text == "Place Target")
        {
            degrees = 0;
        }
        else if (targetsign.text == "90 Degrees")
        {
            degrees = 90;
        }
        else if (targetsign.text == "135 Degrees")
        {
            degrees = 135;
        }
        else if (targetsign.text == "180 Degrees")
        {
            degrees = 180;
        }

        if (OnOff == 0)
        {
            myText.text = "Off";
        }
        else if (OnOff == 1)
        {
            double c = 0.002228;
            double p = 1.940;
            A = 0.0001917476;

            bool ButtonState = GameObject.Find("Button").GetComponent<Push_Button>().pushed;

            if (ButtonState == true)
            {
                if (degrees == 0)
                {
                    myText.text = "Place Target";
                }
                else
                {
                    b = (Mathf.PI / 180) * degrees;

                    rottext = RotationTarget.transform.rotation.eulerAngles.z;
                    gpm = rottext / 60;//GPM Display
                    Q = gpm * c; //ft^3/s conversion
                    v = Q / A; //Velocity
                    forcetext = (p * Q * v) * (1 - Mathf.Cos(b));
                    myText.text = forcetext.ToString("0.####") + " lbs";
                }
            }
            else
            {
                myText.text = "Turn On Pump";
            }
        }
    }
}
