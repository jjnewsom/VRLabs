using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Button : MonoBehaviour
{
    public float rangeRight;
    public float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    //Calling the StopperMove Script
    private StopperMove stopperMove;

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource pressedsound;
    public AudioSource unpressedsound;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        stopperMove = GameObject.FindObjectOfType<StopperMove>();
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        pushedY = (float) 0.6*startY;
    }

    // Update is called once per frame
    void Update()
    {
        rangeRight = Vector3.Distance(RightAnch.transform.position,this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
        {
            if (pushed == false)
            {
                pushed = true;
                pressedsound.Play(0);
                rend.material.color = Color.green;
            }
            else if(pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = Color.red;
            }
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
        {
            if (pushed == false)
            {
                pushed = true;
                pressedsound.Play(0);
                rend.material.color = Color.green;
            }
            else if (pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = Color.red;
            }
        }

        stopperMove.PosReset(pushed);

        if (pushed == true)
        {
            this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);
        }
        else if (pushed == false)
        {
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }
    }
}


