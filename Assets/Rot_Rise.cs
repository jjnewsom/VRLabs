using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_Rise : MonoBehaviour
{
    private float startX;
    private float startY;
    private float startZ;
    public float finalY = 150.2f;
    public GameObject Rotameter;
    // Start is called before the first frame update
    void Start()
    {
        startX = this.gameObject.transform.localPosition.x;
        startY = this.gameObject.transform.localPosition.y;
        startZ = this.gameObject.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        float gpmpercent = GameObject.Find("Flowrate_Text").GetComponent<FlowrateReader>().gpmpercent;
        float newY = (finalY - startY) * gpmpercent / 100;
        this.gameObject.transform.localPosition = new Vector3(startX, newY, startZ);
    }
}