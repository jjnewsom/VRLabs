using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotScript : MonoBehaviour
{
    public bool state1;
    public bool state2;
    public bool state3;
    public GameObject WeightPrompt;
    private float timereq;
    private float rotationlimit = 12.0f;
    public bool rotated = false;
    public Text check;
    public Text weight;

    // Update is called once per frame
    void Update()
    {
        
        bool ButtonOn = GameObject.Find("Cylinder").GetComponent<Push_Button>().pushed;
        state1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        int target1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().snappedweight;
        state2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        state3 = GameObject.Find("Stopper_Snap").GetComponent<StopperSnap>().stopperplaced;
        int target2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().snappedweight;

        double massflow = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().massflow;
        int TotalWeight = target1 + target2;
        timereq = (float) (3 * TotalWeight / (massflow * Mathf.Abs(rotationlimit)));

        float xAngle = TotalWeight / 6f * rotationlimit;
        check.text = transform.eulerAngles.ToString();
        weight.text = TotalWeight.ToString();

        if (ButtonOn == true)
        {
            if (state3 == true)
            {
                if (massflow > 0)
                {
                    if (state1 == true || state2 == true) // or statement
                    {
                        
                        if (rotated == false && transform.eulerAngles.x != xAngle)
                        {
                            transform.Rotate(Vector3.right, Time.deltaTime * 4);
                            if(transform.eulerAngles.x >= xAngle)
                            {
                                rotated = true;
                            }
                        }

                        if (transform.eulerAngles.x > 0 && rotated == true)
                        {
                            // Rotate the object around its local X axis at 1 degree per second
                            transform.Rotate(Vector3.left, Time.deltaTime * 4 / timereq); // RotationDriveMode sped up x4
                        }
                        else if(rotated == true && transform.eulerAngles.x <= 0)
                        {
                            transform.eulerAngles = new Vector3(0, 270f, 0);
                            transform.Rotate(Vector3.zero);
                        }
                    }
                    else if (state1 == false && state2 == false)
                    {
                        if (transform.eulerAngles.x == 0)
                        {
                            bool WeightPromptExists = (GameObject.FindWithTag("addweight") != null);

                            if (WeightPromptExists == false)
                            {
                                Instantiate(WeightPrompt);
                            }
                        }
                        else if (transform.eulerAngles.x <= 0)
                        {
                            transform.eulerAngles = new Vector3(0, 270f, 0);
                            transform.Rotate(Vector3.zero);
                        }
                    }
                }
            }   
        }
    }

    public void Reset()
    {
        rotated = false;
    }
}
