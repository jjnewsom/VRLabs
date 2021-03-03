using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grow : MonoBehaviour
{
    public Transform ninetyDeflection;
    public Transform oneThirtyFiveDeflection;
    public Transform oneEightyDeflection;

    private float startX;
    private float startY;
    private float startZ;

    private int block;

    private bool checker;

    // Start is called before the first frame update
    void Start()
    {
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        block = GameObject.Find("Force Text").GetComponent<ForceReader>().degrees;
        int OnOff = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;
        bool ButtonOn = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        if (OnOff == 1)
        {

            if (ButtonOn == true)
            {
                //Instantiate(WaterPrefab, transform.position, Quaternion.identity);

                if (this.gameObject.transform.localScale.z <= 0.435)
                {
                 this.gameObject.transform.localScale += new Vector3(0, 0, 0.042f);
                }

            }
            else
            {
                this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
            }
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }
    }

    //This should spawn the water deflection
    void OnCollisionExit(Collision collision)
    {
        if(block == 90)
        {
            Instantiate(ninetyDeflection);
        }
        else if (block == 135)
        {
            Instantiate(oneThirtyFiveDeflection);
        }
        else if (block == 180)
        {
            Instantiate(oneEightyDeflection);
        }
    }
    
}
