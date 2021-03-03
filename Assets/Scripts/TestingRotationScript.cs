using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingRotationScript : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    private float rottext; //Rotation Angle
    private float gpm; //GPM
    private float forcetext;
    private float Q; //Float rate in ft^3/s
    private float v; //ft/s
    private float A; //area
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

        if (OnOff == 0)
        {
            myText.text = " ";
        }
        else if (OnOff == 1)
        {
            double c = 0.002228;
            double p = 1.940;
            double d = 1 / 4096;
            double A = 0.0001917476;

            float rottext = RotationTarget.transform.rotation.eulerAngles.z;
            float gpm = rottext / 60;//GPM Display
            double Q = gpm * c; //ft^3/s conversion
            double v = Q / A; //Velocity
            double forcetext = (p * Q * v);
            myText.text = OnOff.ToString() + rottext.ToString("##0") + " Degrees" + "\n" + gpm.ToString("0.##") + " GPM" + "\n" + forcetext.ToString("0.####") + " lbs";
        }
    }
}
