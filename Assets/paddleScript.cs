using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
	public bool rightHanded;
	public bool debugFist;
	public float[] rOffset1 = new float[3];	
	public float[] rOffset2 = new float[3];	
	public float pOffset1;
	public float pOffset2;
	public float impactValue;
	
	private string handString;
	private GameObject hand;
	private Transform centerEye;
    // Start is called before the first frame update
    void Start()
    {	
		if(rightHanded)
		{
			handString = "right";
		}
		else
		{
			handString = "left";
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(hand == null)
		{
			hand = GameObject.FindWithTag("leftHand");
			if(rightHanded)
			{
				hand = GameObject.FindWithTag("rightHand");
			}
		}
		if(centerEye == null)
		{
			centerEye = GameObject.FindWithTag("MainCamera").transform;
		}	
		updatePaddle();
    }
	void updatePaddle()
	{
		if(checkFist(this.handString))
		{
			this.transform.position = hand.transform.position + hand.transform.forward * pOffset1;
			this.transform.rotation = hand.transform.rotation * Quaternion.Euler(rOffset1[0], rOffset1[1],rOffset1[2]);
		}
		else
		{
			this.transform.position = hand.transform.position + hand.transform.forward * pOffset2;
			this.transform.rotation = hand.transform.rotation * Quaternion.Euler(rOffset2[0], rOffset2[1],rOffset2[2]);
		}
		checkFist("right");
	}
	bool checkFist(string handString)
	{
		Debug.Log(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger));
		if(handString == "right")
		{
			if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > .9f && (OVRInput.Get(OVRInput.Button.SecondaryThumbstick) || OVRInput.Get(OVRInput.Touch.SecondaryThumbstick)))//Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x) > 0 || Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y) > 0))
			{
				return true;
			}
		}
		else if(handString == "left")
		{
			if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > .9f && (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)))//Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x) > 0 || Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y) > 0))
			{
				return true;
			}
		}
		return false;
	}
	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball")
		{
			collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * impactValue,ForceMode.Impulse);
			//collision.gameObject.getComponent<Renderer>().material == 
		}
    }
}
