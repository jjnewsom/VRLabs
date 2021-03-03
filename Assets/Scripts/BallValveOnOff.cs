using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallValveOnOff : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    private float rottext; //Rotation Angle
    public int BallValveState;
    public Text PumpOnOff;
    private bool ButtonOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rottext = RotationTarget.transform.rotation.eulerAngles.y;
        ButtonOn = GameObject.Find("Button").GetComponent<Push_Button>().pushed;

        if (rottext > 274)
        {
            BallValveState = 0;
            myText.text = "Off";
        }
        else if (rottext < 274)
        {
            BallValveState = 1;
            myText.text = "On";
        }

        if (ButtonOn == true)
        {
            PumpOnOff.text = "On";
        }
        else if (ButtonOn == false)
        {
            PumpOnOff.text = "Off";
        }
    }
}