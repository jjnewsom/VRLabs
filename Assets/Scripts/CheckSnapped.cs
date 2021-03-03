using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSnapped : MonoBehaviour
{
    public bool WeightPlaced;
    public int snappedweight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = gameObject.GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();

        if (target != null && target.tag == "weight2")
        {
            WeightPlaced = true;
            snappedweight = 2;
        }
        else if (target != null && target.tag == "weight4")
        {
            WeightPlaced = true;
            snappedweight = 4;
        }
        else if (target == null)
        {
            WeightPlaced = false;
            snappedweight = 0;
        }
    }
}
