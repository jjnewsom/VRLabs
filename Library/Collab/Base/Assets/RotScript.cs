using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotScript : MonoBehaviour
{
    private bool state1;
    private bool state2;
    private double var;
    public GameObject WeightPrompt;

    // Update is called once per frame
    void Update()
    {
        state1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        int target1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().snappedweight;
        var = 0.1; 
        state2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        int target2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().snappedweight;
        {
            if (state1 == true || state2 == true) // or statement
            {
                while (transform.localRotation.x < 7.467)
                {                
                    // Rotate the object around its local X axis at 1 degree per second
                    transform.Rotate(Vector3.right * Time.deltaTime);
                }
            }
            else if (state1 == false && state2 == false)
            {
                if (transform.localRotation.x == 0)
                {
                    bool WeightPromptExists = (GameObject.FindWithTag("addweight") != null);

                    if (WeightPromptExists == false)
                    {
                        Instantiate(WeightPrompt);
                    }
                }
                else if (transform.localRotation.x > 1)
                {
                    transform.Rotate(Vector3.left * Time.deltaTime);
                }
                else if (transform.localRotation.x < 0)
                {
                    transform.Rotate(0, 0, 0);
                }
            }
        }
    }
}
