using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopperSnap : MonoBehaviour
{
    public bool stopperplaced;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject stopper = gameObject.GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
        if (stopper != null)
        {
            stopperplaced = true;
        }
        else if (stopper = null)
        {
            stopperplaced = false;
        }

    }
}
