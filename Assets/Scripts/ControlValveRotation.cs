using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlValveRotation : MonoBehaviour
{
    private GameObject handle;
    private Renderer rend;
    public GameObject RotationTarget;
    Collider valvecollid1;
    Collider valvecollid2;
    Collider valvecollid3;
    Collider valvecollid4;
    Collider valvecollid5;
    Collider valvecollid6;
    Collider valvecollid7;
    Collider valvecollid8;
    private bool pumponoff;
    public float rottext; //Rotation Angle
    private bool startBlink = true;
    private IEnumerator blinking;
    private Color SetColor;
    private Color BlinkColor = Color.blue;
    public bool ValveSet;

    // Start is called before the first frame update
    void Start()
    {
        handle = RotationTarget.transform.GetChild(0).gameObject;

        blinking = ColorChanger();
        rend = handle.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rottext = RotationTarget.transform.localRotation.eulerAngles.y;

        if (rottext < 5)
        { 
            if (handle.name == "ball valve handle (3)" || handle.name == "ball valve handle (4)" || handle.name == "ball valve handle (8)")
            {
                ValveSet = true;
            }
            if (handle.name == "ball valve handle (onoff)" || handle.name == "ball valve handle (2)" || handle.name == "ball valve handle (5)" || handle.name == "ball valve handle (6)" || handle.name == "ball valve handle (7)")
            {
                ValveSet = false;
            }
        }
        else if (rottext > 5)
        {
            if (handle.name == "ball valve handle (3)" || handle.name == "ball valve handle (4)" || handle.name == "ball valve handle (8)")
            {
                ValveSet = false;
            }
            if (handle.name == "ball valve handle (onoff)" || handle.name == "ball valve handle (2)" || handle.name == "ball valve handle (5)" || handle.name == "ball valve handle (6)" || handle.name == "ball valve handle (7)")
            {
                ValveSet = true;
            }
        }
        //Color Changing
        bool BuzzerOn = GameObject.Find("Button").GetComponent<Push_Button>().BuzzerWentOff;
        if (BuzzerOn == true && startBlink && ValveSet == false)
        {
            StartCoroutine(blinking);
            startBlink = false;
        }
        if (BuzzerOn == false || ValveSet == true)
        {
            StopCoroutine(blinking);
            startBlink = true;

            rend.material.color = SetColor;
        }

        if (handle.name == "ball valve handle (onoff)")
        {
            SetColor = Color.yellow;
        }
        else
        {
            SetColor = Color.red;
        }

        pumponoff = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        valvecollid1 = GameObject.Find("ball valve handle (onoff)").GetComponent<Collider>();
        valvecollid2 = GameObject.Find("ball valve handle (2)").GetComponent<Collider>();
        valvecollid3 = GameObject.Find("ball valve handle (3)").GetComponent<Collider>();
        valvecollid4 = GameObject.Find("ball valve handle (4)").GetComponent<Collider>();
        valvecollid5 = GameObject.Find("ball valve handle (5)").GetComponent<Collider>();
        valvecollid6 = GameObject.Find("ball valve handle (6)").GetComponent<Collider>();
        valvecollid7 = GameObject.Find("ball valve handle (7)").GetComponent<Collider>();
        valvecollid8 = GameObject.Find("ball valve handle (8)").GetComponent<Collider>();

        if (pumponoff == true)
        {
            valvecollid1.enabled = false;
            valvecollid2.enabled = false;
            valvecollid3.enabled = false;
            valvecollid4.enabled = false;
            valvecollid5.enabled = false;
            valvecollid6.enabled = false;
            valvecollid7.enabled = false;
            valvecollid8.enabled = false;
        }
        else if (pumponoff == false)
        {
            valvecollid1.enabled = true;
            valvecollid2.enabled = true;
            valvecollid3.enabled = true;
            valvecollid4.enabled = true;
            valvecollid5.enabled = true;
            valvecollid6.enabled = true;
            valvecollid7.enabled = true;
            valvecollid8.enabled = true;
        }
    }
    IEnumerator ColorChanger()
    {
        while (true)
        {
            rend.material.color = SetColor;
            yield return new WaitForSeconds(1);
            rend.material.color = BlinkColor;
            yield return new WaitForSeconds(1);
        }
        

    }
}