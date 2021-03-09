using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpEquations : MonoBehaviour
{

    private float Qgpm;
    private float rpm;
    private float Adischarge;
    private float Asuction;
    private float g = 32.2f;
    private float gamma = 62.4f;

    private float Qcfs;
    private float Vdischarge;
    private float Vsuction;
    private float omega;
    private float efficiency;

    public Text Pressure;
    public Text Torque;

    // Start is called before the first frame update
    void Start()
    {
        float Ddischarge = (float) 1.25 / 12;
        float Dsuction = (float) 1.5 / 12;

        Adischarge = Mathf.PI * Mathf.Pow(Ddischarge, 2) / 4;
        Asuction = Mathf.PI * Mathf.Pow(Dsuction, 2) / 4;
    }

    // Update is called once per frame
    void Update()
    {
        Qgpm = GameObject.Find("Flow Rate").GetComponent<FlowRate>().flowrate;
        rpm = GameObject.Find("Button (Speed)").GetComponent<SpeedButton>().SpeedState;


        Qcfs = Qgpm * 0.002228f;
        Vdischarge = Qcfs / Adischarge;
        Vsuction = Qcfs / Asuction;

        float hp = Mathf.Pow(Vdischarge, 2) - Mathf.Pow(Vdischarge, 2) / (2 * g);
        float deltaP = hp * gamma / 144;

        if (rpm == 1150)
        {
            if (Qgpm >= 13 && Qgpm <= 45.6)
            {
                efficiency = (float) ((-0.0006*Mathf.Pow(Qgpm, 3) - 0.0036 * Mathf.Pow(Qgpm, 2) + 1.7819 * Qgpm + 8.4786)/100);
            }
            else if (Qgpm < 13 || Qgpm > 45.6)
            {
                efficiency = 0.3f;
            }

        }
        else if (rpm == 1750)
        {
            if (Qgpm >= 14.5 && Qgpm <= 72)
            {
                efficiency = (float)((-0.0234 * Mathf.Pow(Qgpm, 2) + 2.0955 * Qgpm + 4.9893) / 100);
            }
            else if (Qgpm < 14.5)
            {
                efficiency = 0.3f;
            }
            else if (Qgpm > 72)
            {
                efficiency = 0.35f;
            }
        }
        efficiency = 0.4f;

        omega = rpm * 0.104719755f;

        float Wout = gamma * Qcfs * hp;
        float Win = Wout / efficiency;
        float T = Win / omega;

        bool PumpState = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        if (PumpState == true)
        {
            Pressure.text = deltaP.ToString("0.##") + " psi";
            Torque.text = T.ToString("0.####") + " ft-lb";
        }
        else if (PumpState == false)
        {
            Pressure.text = "Off";
            Torque.text = "Off";
        }
    }
}
