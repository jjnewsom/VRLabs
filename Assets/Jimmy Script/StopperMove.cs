using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperMove : MonoBehaviour
{
    public static bool MoveS = false;
    public static double travelS = 0f;
    //public GameObject stopper;
    float zpos;
    float xpos;
    float ypos;
    float zfinal;
    public bool check = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveS == true)
        {
            this.gameObject.transform.Translate(0, 0, -0.01f);
            travelS += 0.01f;
            if (travelS >= 0.5f)
            {  
                MoveS = false;
                
            }    
            
        }
        if(this.gameObject.transform.position.z == -0.4609998)
        {
            check = false;
        }
        zpos = this.gameObject.transform.position.z;
        xpos = this.gameObject.transform.position.x;
        ypos = this.gameObject.transform.position.y;
        if (check == false && this.gameObject.transform.position.z <= -0.4609998)
        {
            this.gameObject.transform.position = new Vector3(xpos, ypos, zpos);
        }
    }

    //Make things Move
    private void OnCollisionEnter(Collision fluid)
    {
        if (fluid.transform.tag == "WaterSpout")
        {
            MoveS = true;
            check = false;
        }
    }
}