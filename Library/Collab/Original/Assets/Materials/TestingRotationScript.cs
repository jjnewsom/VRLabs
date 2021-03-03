using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingRotationScript : MonoBehaviour
{
    public GameObject RotationTarget;
    public Text myText;
    private float rottext; //Rotation Angle
    private float rotturns; //GPM
    private float forcetext;
    private float Q; //Float rate in ft^3/s
    private float v; //ft/s
    private float A; //area
    //private float p; //density (slugs/ft^3)
    //private float ctheta; //angle
    
    // Start is called before the first frame update
    void Start()
    {
        double b = 2.71267;        
        float A = (Mathf.PI / 4) * Mathf.Pow((float)b, -5);        
        //float p = 1.940f;
        //float ctheta = 90;
    }

    // Update is called once per frame
    void Update()
    {
        double c = 0.00228;
        float rottext = (int) RotationTarget.transform.rotation.eulerAngles.z;
        float rotturns = rottext / 60;//GPM Display
        float Q = rottext * (float)c; //ft^3/s conversion
        float v = Q / A; //Velocity
        float forcetext = (1.940f * Q * v);
        myText.text = rottext.ToString() + " Degrees" + "\n" + rotturns.ToString("#0.00") + " GPM" + "\n" + Q.ToString("#0.00") + " lbs";
    }
}
