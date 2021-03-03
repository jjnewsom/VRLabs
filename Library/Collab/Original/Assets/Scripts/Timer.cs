using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int TotalWeight;
    private bool state1;
    private bool state2;
    private bool weightchanged;
    public float weighttimer = 0f;
    public Text myTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().WeightPlaced;
        int target1 = GameObject.Find("Weight 1").GetComponent<CheckSnapped>().snappedweight;

        state2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().WeightPlaced;
        int target2 = GameObject.Find("Weight 2").GetComponent<CheckSnapped>().snappedweight;

        GameObject rotobject = GameObject.Find("MM_Box and Weight_Fix");

        if (state1 == false && state2 == false)
        {
            weighttimer = 0f;
        }

        while (rotobject.transform.rotation.x < 7.467)
        {
            weighttimer += Time.deltaTime;
        }

        TotalWeight = target1 + target2;
        myTimer.text = "Weight: " + TotalWeight.ToString() + " kg" + "\n" + "Time: " + weighttimer.ToString("0.#") + " sec";
    }

    public IEnumerator WeightChange()
    {
        bool state1first = state1;
        bool state2first = state2;
        yield return new WaitForSeconds(0.083f);
        bool state1second = state1;
        bool state2second = state2;

        if (state1first == state1second && state2first == state2second)
        {
            weightchanged = false;
        }
        else if (state1first != state1second || state2first != state2second)
        {
            weightchanged = true;
            weighttimer = 0f;
        }
    }
}
