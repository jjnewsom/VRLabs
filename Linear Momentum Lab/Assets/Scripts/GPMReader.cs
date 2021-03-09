using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPMReader : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    private float rottext; //Rotation Angle
    public float gpm; //GPM

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rottext = RotationTarget.transform.rotation.eulerAngles.z;
        gpm = rottext / 60;
        int OnOff = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;

        if (OnOff == 0)
        {
            myText.text = "Off";
        }
        else if (OnOff == 1)
        {
            myText.text = gpm.ToString("0.##") + " GPM";
        }
    }
}
