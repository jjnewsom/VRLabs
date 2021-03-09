using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSnapped : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("SnapDropZone").GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
        if (target.name == "90 Target")
        {
            myText.text = "90";
        }
        else if (target.name == "135 Target")
        {
            myText.text = "135";
        }
        else if (target.name == "180 Target")
        {
            myText.text = "180";
        }
        else if (target != null)
        {
            myText.text = "Place Target";
        }
    }
}
