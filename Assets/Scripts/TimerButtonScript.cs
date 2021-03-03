using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtonScript : MonoBehaviour
{
    private float rangeRight;
    private float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    public AudioSource pressedsound;
    public AudioSource unpressedsound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.One) && rangeRight <= 0.25)
        {
            if (pushed == false)
            {
                pushed = true;
                pressedsound.Play(0);
                rend.material.color = Color.white;
            }
            else if (pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = new Color(1, 0, 0, 0.75f);
            }
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Three) && rangeLeft <= 0.25)
        {
            if (pushed == false)
            {
                pushed = true;
                pressedsound.Play(0);
                rend.material.color = Color.white;
            }
            else if (pushed == true)
            {
                pushed = false;
                unpressedsound.Play(0);
                rend.material.color = new Color(1, 0, 0, 0.75f);
            }
        }
    }
}
