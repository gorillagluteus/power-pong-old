using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
	public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    	this.transform.position = hand.transform.position;
    	this.transform.rotation = hand.transform.rotation * Quaternion.Euler(0,0,0);
    }
}
