using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparatusMove : MonoBehaviour
{
    /*
    private double distbetween = 0.509999988600612f;
    private double disp = 0.5f;
    private double total = 1.009999988600612f;
    private double travela = 0f;
    */
    //you got to make a public game object variable so you can drag the object into bar of unity
    public float stopPosY;
    public float stopPosX;
    public float stopPosZ;


    // Start is called before the first frame update
    void Start()
    {
        stopPosY = GameObject.Find("Linear Momentum Apparatus Base").transform.position.y;
        stopPosX = GameObject.Find("Linear Momentum Apparatus Base").transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        stopPosZ = GameObject.Find("Stopper").transform.position.z;
        this.gameObject.transform.localPosition = new Vector3(stopPosX, stopPosY, stopPosZ);
    }

}

    


