using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(-2, 1, 1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
