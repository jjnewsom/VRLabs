using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotScript : MonoBehaviour
{
    public bool state1;
    public bool state2;
    public bool state3;
    private int TotalWeight;
    public GameObject WeightPrompt;
    private float timereq;
    private float rotationlimit = 12.0f;
    public bool rotated = false;
    public bool rotatedUp = false;
    public Text check;
    public Text weight;
    public float xAngle;
    private bool AddedWeight;

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
        TotalWeight = target1 + target2;
        timereq = (float) (3 * TotalWeight / (massflow * Mathf.Abs(xAngle)));

        xAngle = TotalWeight / 6f * rotationlimit;
        check.text = transform.eulerAngles.ToString();
        weight.text = TotalWeight.ToString();

        StartCoroutine(WeightChangeCheck());
        if (AddedWeight == true)
        {
            rotated = false;
        }

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

                        if (transform.eulerAngles.x > 0 && rotated == true && rotatedUp == false)
                        {
                            // Rotate the object around its local X axis at 1 degree per second
                            transform.Rotate(Vector3.left, Time.deltaTime * 4 / timereq); // RotationDriveMode sped up x4
                            if(transform.eulerAngles.x == 0 || transform.eulerAngles.x > 350)
                            {
                                rotatedUp = true;
                            }
                        }
                        else if(rotated == true && rotatedUp == true)
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

        rotatedUp = false;
    }

    public IEnumerator WeightChangeCheck()
    {
        int beforeweight = TotalWeight;
        yield return new WaitForSeconds(0.083f);
        int afterweight = TotalWeight;

        if (beforeweight == afterweight)
        {
            AddedWeight = false;
        }
        else if (beforeweight != afterweight)
        {
            AddedWeight = true;
        }
    }
}
