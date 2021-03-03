using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_Grow : MonoBehaviour
{
    private float startX;
    private float startY;
    private float startZ;
    public GameObject WaterLevel;
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
        float gpmpercent = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().gpmpercent;
        float newY = startY * gpmpercent;
        this.gameObject.transform.localScale = new Vector3(startX, newY, startZ);
    }
}
