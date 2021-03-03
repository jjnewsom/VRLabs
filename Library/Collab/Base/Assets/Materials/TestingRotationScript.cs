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
        float A = (Mathf.PI / 4) * Mathf.Pow(2.713f, -5);        
        //float p = 1.940f;
        //float ctheta = 90;
    }

    // Update is called once per frame
    void Update()
    {
        float rottext = (int) RotationTarget.transform.rotation.eulerAngles.z;
        float rotturns = rottext / 60;//GPM Display
        float Q = rottext * 0.002228f; //ft^3/s conversion
        float v = Q / A; //Velocity
        float forcetext = (1.940f * Q * v);
        myText.text = rottext.ToString() + " Degrees" + "\n" + rotturns.ToString("#0.00") + " GPM" + "\n" + A.ToString("#0.00") + " lbs";
    }
}
