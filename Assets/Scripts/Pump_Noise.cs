using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Noise : MonoBehaviour
{
    public bool start;
    public AudioSource pump;
    public AudioSource water;
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        bool pumponoff = GameObject.Find("Cylinder").GetComponent<Push_Button>().pushed;
        bool startplaying = GameObject.Find("Cylinder").GetComponent<Push_Button>().StartPumpSound;

        if (pumponoff == true)
        {
            if (startplaying == true)
            {
                pump.Play(0);
                water.Play(0);
            }
        }
        else if (pumponoff == false)
        {
            pump.Stop();
            water.Stop();
        }
    }

    
}
