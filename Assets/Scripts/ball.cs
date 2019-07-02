using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
	private bool hasNinja;
	private bool hasWarp;
	private bool hasScatter;
	private bool hasCharge;
	private bool hasPsychic;
	private int speed;
    // Start is called before the first frame update
    public ball (bool hasNinja, bool hasWarp, bool hasScatter, bool hasCharge, bool hasPsychic)
    {
    	this.speed = 0;
    	this.hasNinja = hasNinja;
    	this.hasWarp = hasWarp;
    	this.hasScatter = hasScatter;
    	this.hasCharge = hasCharge;
    	this.hasPsychic = hasPsychic;
    }
    void Start()
    {
       hasNinja = false;
       hasWarp = false;
       hasScatter = false;
       hasCharge = false;
       hasPsychic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
