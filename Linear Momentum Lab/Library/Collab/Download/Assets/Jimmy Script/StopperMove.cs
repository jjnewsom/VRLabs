using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperMove : MonoBehaviour
{
    public static bool MoveS = false;
    public static double travelS = 0f;
    //public GameObject stopper;
    float izpos;
    float ixpos;
    float iypos;
    public bool check = true;

    public Transform ninetyDeflection;
    public Transform oneThirtyFiveDeflection;
    public Transform oneEightyDeflection;
    private int block;
    private int ValveState;
    private bool ButtonState;
    private float GPMread;


    // Start is called before the first frame update
    void Awake()
    {
        izpos = this.gameObject.transform.position.z;
        ixpos = this.gameObject.transform.position.x;
        iypos = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        block = GameObject.Find("Force Text").GetComponent<ForceReader>().degrees;
        ValveState = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;
        ButtonState = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        GPMread = GameObject.Find("GPM Text").GetComponent<GPMReader>().gpm;

        if (ValveState == 0)
        {
            Destroy(GameObject.FindWithTag("Reflect"));
        }
        if (ButtonState == false)
        {
            Destroy(GameObject.FindWithTag("Reflect"));
        }
        if (GPMread < 0.01)
        {
            Destroy(GameObject.FindWithTag("Reflect"));
        }
    }
    //Make things Move
    private void OnCollisionStay(Collision fluid)
    {
        if (fluid.transform.tag == "WaterSpout")
        {
            this.gameObject.transform.Translate(0, 0, -0.025f);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (block == 90)
        {
            Instantiate(ninetyDeflection);
        }
        else if (block == 135)
        {
            Instantiate(oneThirtyFiveDeflection);
        }
        else if (block == 180)
        {
            Instantiate(oneEightyDeflection);
        }
    }


    //Grow Interaction
    public void PosReset(bool pushed)
    {
        if(pushed == false)
        {
            this.gameObject.transform.position = new Vector3(ixpos, iypos, izpos);
        }
    }
}