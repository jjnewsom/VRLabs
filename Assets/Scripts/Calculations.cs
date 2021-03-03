using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    public int[] A = new int[] { 285, 252, 124, 122, 184, 174};
    public int[] B = new int[] { 125, 136, 142, 148, 152, 157};
    public int[] C = new int[] { 270, 238, 214, 194, 180, 170};
    public int[] D = new int[] { 272, 240, 216, 196, 182, 170};
    public int[] E = new int[] { 285, 250, 220, 200, 184, 172};
    public int[] F = new int[] { 90, 112, 126, 138, 146, 154};
    public int[] G = new int[] { 122, 132, 142, 148, 152, 156};
    public int[] H = new int[] { 118, 128, 138, 146, 152, 156};
    public int[] I = new int[] { 10, 28, 36, 44, 50, 50 };

    public double Pa;
    public double Pb;
    public double Pc;
    public double Pd;
    public double Pe;
    public double Pf;
    public double Pg;
    public double Ph;
    public double Pi;

    public Text Pa_text;
    public Text Pb_text;
    public Text Pc_text;
    public Text Pd_text;
    public Text Pe_text;
    public Text Pf_text;
    public Text Pg_text;
    public Text Ph_text;
    public Text Pi_text;

    public float gpmpercent;


    // Update is called once per frame
    void Update()
    {
        float gpmpercentage = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().gpmpercent;
        gpmpercent = gpmpercentage / 100f;
        if(gpmpercent <= .25f)
        {
            Pa = 0;
            Pb = 0;
            Pc = 0;
            Pd = 0;
            Pe = 0;
            Pf = 0;
            Pg = 0;
            Ph = 0;
            Pi = 0;
        }
        else
        {
            // Manometer Pressure Readings (mm H2O)
            Pa = -7.4375 * Mathf.Pow(gpmpercent, 4) + 103.47 * Mathf.Pow(gpmpercent, 3) - 473.66 * Mathf.Pow(gpmpercent, 2) + 770.29 * gpmpercent - 106.83;    // R² = 0.9922
            Pb = -0.6786 * Mathf.Pow(gpmpercent, 2) + 10.864 * gpmpercent + 115.6;    // R² = 0.9942
            Pc = 2.6786 * Mathf.Pow(gpmpercent, 2) - 38.579 * gpmpercent + 305.4;    // R² = 0.9998
            Pd = 2.5 * Mathf.Pow(gpmpercent, 2) - 37.614 * gpmpercent + 306.4;    // R² = 0.9995 
            Pe = 3.0536 * Mathf.Pow(gpmpercent, 2) - 43.746 * gpmpercent + 325.3; // R² = 0.9995
            Pf = -1.6786 * Mathf.Pow(gpmpercent, 2) + 24.15 * gpmpercent + 68.6;    // R² = 0.9974
            Pg = -0.9643 * Mathf.Pow(gpmpercent, 2) + 13.493 * gpmpercent + 109.4;    // R² = 0.998
            Ph = -0.8214 * Mathf.Pow(gpmpercent, 2) + 13.464 * gpmpercent + 105;    // R² = 0.9993
            Pi = -1.75 * Mathf.Pow(gpmpercent, 2) + 20.079 * gpmpercent - 7.4;    // R² = 0.9929
        }

        /*Pa_text.text = Pa.ToString();
        Pb_text.text = Pb.ToString();
        Pc_text.text = Pc.ToString();
        Pd_text.text = Pd.ToString();
        Pe_text.text = Pe.ToString();
        Pf_text.text = Pf.ToString();
        Pg_text.text = Pg.ToString();
        Ph_text.text = Ph.ToString();
        Pi_text.text = Pi.ToString();*/

        Pa_text.text = Pa.ToString("F0");
        Pb_text.text = Pb.ToString("F0");
        Pc_text.text = Pc.ToString("F0");
        Pd_text.text = Pd.ToString("F0");
        Pe_text.text = Pe.ToString("F0");
        Pf_text.text = Pf.ToString("F0");
        Pg_text.text = Pg.ToString("F0");
        Ph_text.text = Ph.ToString("F0");
        Pi_text.text = Pi.ToString("F0");
    }
}
