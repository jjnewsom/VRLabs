using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grow : MonoBehaviour
{
    double distBetween = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int OnOff = GameObject.Find("Ball Valve State").GetComponent<BallValveOnOff>().BallValveState;
        if (OnOff == 1)
        {
            if (this.gameObject.transform.localScale.z <= 0.435)
            {
                this.gameObject.transform.localScale += new Vector3(0, 0, 0.042f);
            }
        }
        
    }
}
