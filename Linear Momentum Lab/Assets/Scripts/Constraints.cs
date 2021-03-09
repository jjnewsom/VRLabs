using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour
{
    float lowestPosition = 4f;
    float highestPosition = 4.2f;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.y > lowestPosition)
        {

        }
        else(transform.position.y < highestPosition)
        {

        }*/
    }
}
