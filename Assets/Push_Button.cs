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
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rangeRight = Vector3.Distance(RightAnch.transform.position,this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeRight <= 0.125)
        {
            if (pushed == false)
            {
                pushed = true;
                rend.material.color = Color.green;
            }
            else if(pushed == true)
            {
                pushed = false;
                rend.material.color = Color.red;
            }
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeLeft <= 0.125)
        {
            if (pushed == false)
            {
                pushed = true;
                rend.material.color = Color.green;
            }
            else if (pushed == true)
            {
                pushed = false;
                rend.material.color = Color.red;
            }
        }
    }
}


