using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage_Dynamic_Text_Thing : MonoBehaviour
{
    // Start is called before the first frame update
    float xPos;
    float yPos;
    float zPos;
    
    Text Text;
    void Start()
    {
        Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = GameObject.FindGameObjectWithTag("Cube").transform.position.x;
        yPos = GameObject.FindGameObjectWithTag("Cube").transform.position.y;
        zPos = GameObject.FindGameObjectWithTag("Cube").transform.position.z;
        Text.text = "X Position " + xPos + "Y Position " + yPos + "Z Position " + zPos;
    }
}
