using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    public GameObject weight2;
    public bool state1;
    public int target1;
    public bool state2;
    public int target2;
    public GameObject weight4;
    public GameObject massLever;
    private Vector3 position2;
    private Vector3 position4;

    private float rangeRight;
    private float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public AudioSource pressedsound;
    public AudioSource unpressedsound;
    public bool ResetNow = false;

    public Push_Button pushButton;
    public RotScript rotScript;

    // Start is called before the first frame update
    void Start()
    {
        position2 = weight2.transform.position;
        position4 = weight4.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        state1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        target1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().snappedweight;

        state2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        target2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().snappedweight;

        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
        {

            pressedsound.Play(0);
            //pushButton.Off();
            Reset();
            //pushButton.On();
            unpressedsound.Play(0);
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
        {
            pressedsound.Play(0);
            //pushButton.Off();
            Reset();
            //pushButton.On();
            unpressedsound.Play(0);
        }
    }

    public void Reset()
    {
        weight2.transform.position = position2;
        state1 = false;
        target1 = 0;

        weight4.transform.position = position4;
        state2 = false;
        target2 = 0;

        rotScript.Reset();
        massLever.transform.eulerAngles = new Vector3(359.99f,270f,0);
        massLever.transform.Rotate(Vector3.zero);
        Text timer = GameObject.Find("Timer").GetComponent<Timer>().myTimer;
        timer.text = "";
    }
}
