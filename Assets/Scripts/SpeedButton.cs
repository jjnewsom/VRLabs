using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class SpeedButton : MonoBehaviour
{
    public float rangeRight;
    public float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource pressedsound;
    public int SpeedState = 1150;
    Collider speedcollid;
    public GameObject SpeedWarning;
    public AudioSource warningsound;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        pushedY = (float)0.6 * startY;
    }

    // Update is called once per frame
    void Update()
    {
        bool pumponoff = GameObject.Find("Button").GetComponent<Push_Button>().pushed;

        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);

        if (pumponoff == false)
        {
            // for right hand
            if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
            {
                pressedsound.Play(0);
                rend.material.color = Color.green;
                this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);

                if (SpeedState == 1150)
                {
                    SpeedState = 1750;
                }
                else
                {
                    SpeedState = 1150;
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.One))
            {
                rend.material.color = new Color(1, 0, 0, 0.75f);
                this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
            }

            //for left hand
            if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
            {
                pressedsound.Play(0);
                rend.material.color = Color.green;
                this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);

                if (pumponoff == false)
                {
                    if (SpeedState == 1150)
                    {
                        SpeedState = 1750;
                    }
                    else
                    {
                        SpeedState = 1150;
                    }
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.Three))
            {
                rend.material.color = new Color(1, 0, 0, 0.75f);
                this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
            }
        }
        else
        {
            bool PromptExists = (GameObject.FindWithTag("SpeedButtonOff") != null);

            if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
            {
                if (PromptExists == false)
                {
                    warningsound.Play(0);
                    Instantiate(SpeedWarning);
                    Destroy(GameObject.FindWithTag("SpeedButtonOff"), 1);
                }
            }

            if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
            {
                if (PromptExists == false)
                {
                    warningsound.Play(0);
                    Instantiate(SpeedWarning);
                    Destroy(GameObject.FindWithTag("SpeedButtonOff"), 1);
                }
            }
        }
    }
}
