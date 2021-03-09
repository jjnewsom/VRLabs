using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public float rangeRight;
    public float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    //Calling the StopperMove Script

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource WarningSound;
    public GameObject ValveWarning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool pumponoff = GameObject.Find("Button").GetComponent<Push_Button>().pushed;

        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (pumponoff == true)
        {
            //for right hand
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) && rangeRight <= 0.25)
            {
                WarningSound.Play(0);
                bool PromptExists = (GameObject.FindWithTag("Warning") != null);

                if (PromptExists == false)
                {
                    Instantiate(ValveWarning);
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                Destroy(GameObject.FindWithTag("Warning"), 1);
            }

            // for left hand
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && rangeLeft <= 0.25)
            {
                WarningSound.Play(0);
                bool PromptExists = (GameObject.FindWithTag("Warning") != null);

                if (PromptExists == false)
                {
                    Instantiate(ValveWarning);
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                Destroy(GameObject.FindWithTag("Warning"), 1);
            }
        }
    }
}


