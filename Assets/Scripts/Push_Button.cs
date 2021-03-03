using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push_Button : MonoBehaviour
{
    private float rangeRight;
    private float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    //Calling the StopperMove Script

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource pressedsound;
    public AudioSource unpressedsound;
    public bool StartPumpSound = false;

    private Pump_Noise Pump_Noise;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        pushedY = (float)0.6 * startY;

        Pump_Noise = FindObjectOfType<Pump_Noise>();
    }

    // Update is called once per frame
    void Update()
    {
        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
        {
            if (pushed == false)
            {
                On();
            }
            else if (pushed == true)
            {
                Off();
            }
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
        {
            if (pushed == false)
            {
                On();
            }
            else if (pushed == true)
            {
                Off();
            }
        }
    }

    public IEnumerator PumpSound()
    {
        StartPumpSound = true;
        yield return new WaitForSeconds(0.083f);
        StartPumpSound = false;
    }

    public void On()
    {
        pushed = true;
        pressedsound.Play(0);
        rend.material.color = Color.green;
        StartCoroutine(PumpSound());
    }

    public void Off()
    {
        pushed = false;
        unpressedsound.Play(0);
        rend.material.color = new Color(1, 0, 0, 0.75f);
    }
}



