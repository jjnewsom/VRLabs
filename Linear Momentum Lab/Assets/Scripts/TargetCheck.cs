using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCheck : MonoBehaviour
{
	public int a;
	public GameObject gameObject;
	public Text targetread;//global check variable

	void Start()
	{
        
	}
	// Update is called once per frame
	void Update()
	{
    }
	void OnCollisionStay(Collision collision)

	{
		if (collision.gameObject.name == "90 Target")
		{
			a = 90;
			targetread.text = "90 Degrees";
		}
		else if (collision.gameObject.name == "135 Target")
		{
			a = 135;
			targetread.text = "135 Degrees";
		}
		else if (collision.gameObject.name == "180 Target")
		{

			a = 180;
			targetread.text = "180 Degrees";
		}
		else
		{
			a = 0;
            targetread.text = "Place Target";
        }

	}




}
    

		
