using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grow : MonoBehaviour
{
    

    private float startX;
    private float startY;
    private float startZ;

    


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

        int OnOff = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;
        bool ButtonOn = GameObject.Find("Button").GetComponent<Push_Button>().pushed;
        float GPMread = GameObject.Find("GPM Text").GetComponent<GPMReader>().gpm;

        //int OnOff = 1;
        //bool ButtonOn = true;
        if (OnOff == 1)
        {
            if (GPMread >= 0.01)
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
        else
        {
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }
    }

    //This should spawn the water deflection
    
    
}
