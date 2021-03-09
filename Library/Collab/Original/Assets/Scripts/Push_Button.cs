using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push_Button : MonoBehaviour
{
    public float rangeRight;
    public float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    //Calling the StopperMove Script

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource pressedsound;
    public AudioSource unpressedsound;
    private bool ValvesSet = false;
    public AudioSource Buzzer;
    public GameObject BuzzerPrompt;
    public bool BuzzerWentOff = false;

    private Pump_Noise Pump_Noise;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        pushedY = (float) 0.6*startY;

        Pump_Noise = FindObjectOfType<Pump_Noise>();
    }

    // Update is called once per frame
    void Update()
    {
        rangeRight = Vector3.Distance(RightAnch.transform.position,this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
        {
            if (pushed == false)
            {
                if (ValvesSet == true)
                {
                    pushed = true;
                    pressedsound.Play(0);
                    rend.material.color = Color.green;
                    Destroy(GameObject.FindWithTag("Buzzer"));
                    BuzzerWentOff = false;
                }
                else
                {
                    Buzzer.Play(0);
                    bool PromptExists = (GameObject.FindWithTag("Buzzer") != null);
                    BuzzerWentOff = true;

                    if (PromptExists == false)
                    {
                        Instantiate(BuzzerPrompt);
                    }
                }
            }
            else if(pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = new Color(1, 0, 0, 0.75f);
            }
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
        {
            if (pushed == false)
            {
                if (ValvesSet == true)
                {
                    pushed = true;
                    pressedsound.Play(0);
                    rend.material.color = Color.green;
                    Destroy(GameObject.FindWithTag("Buzzer"));
                }
                else
                {
                    Buzzer.Play(0);
                    bool PromptExists = (GameObject.FindWithTag("Buzzer") != null);

                    if (PromptExists == false)
                    {
                        Instantiate(BuzzerPrompt);
                    }
                }
            }
            else if (pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = new Color(1, 0, 0, 0.75f);
            }
        }


        if (pushed == true)
        {
            this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);
        }
        else if (pushed == false)
        {
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }

        bool open1 = GameObject.Find("rotation axis (onoff)").GetComponent<ControlValveRotation>().BallValveState;  //open
        bool open2 = GameObject.Find("rotation axis (2)").GetComponent<ControlValveRotation>().BallValveState;  //open
        bool open3 = GameObject.Find("rotation axis (3)").GetComponent<ControlValveRotation>().BallValveState;
        bool open4 = GameObject.Find("rotation axis (4)").GetComponent<ControlValveRotation>().BallValveState;   //open
        bool open5 = GameObject.Find("rotation axis (5)").GetComponent<ControlValveRotation>().BallValveState;
        bool open6 = GameObject.Find("rotation axis (6)").GetComponent<ControlValveRotation>().BallValveState;
        bool open7 = GameObject.Find("rotation axis (7)").GetComponent<ControlValveRotation>().BallValveState;

        if (open1 == true && open2 == true && open3 == false && open4 == true && open5 == false && open6 == false && open7 == false)
        {
            ValvesSet = true;
        }
        else
        {
            ValvesSet = false;
        }

        //Pump Noises
        if (pushed == true)
        {
            Pump_Noise.playSound();
        }
        else if (pushed == false)
        {
            Pump_Noise.stopSound();
        }
    }
}


