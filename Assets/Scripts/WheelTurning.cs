using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WheelTurning : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    public int rottext = 0; //Rotation Angle
    public float currentAngle;
    public float oldAngle;
    public int deltaAngle;
    // Start is called before the first frame update
    void Start()
    {
        oldAngle = Mathf.FloorToInt(RotationTarget.transform.localRotation.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        //At 0 and 360, remember that new is 0 and old is 359ish so you're delta will be a negative number
        currentAngle = Mathf.FloorToInt(RotationTarget.transform.localRotation.eulerAngles.y);
        deltaAngle = Mathf.FloorToInt(currentAngle - oldAngle);

        if (deltaAngle < -350 && deltaAngle >= -359)
        {
            //count ++;
            rottext += (360 + deltaAngle);
            
        }
        else if (deltaAngle > 350 && deltaAngle <= 359)
        {
            //count--;
            rottext -= (360 - deltaAngle);
            
        }
        else
        {
            rottext += deltaAngle;
        }
        oldAngle = currentAngle;
        myText.text = rottext.ToString();
        oldAngle = currentAngle;
    }
}
