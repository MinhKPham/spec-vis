using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallfaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.y < 30)
        {
            rb.AddForce(Physics.gravity * rb.mass * 40);
        }
        else rb.AddForce(Physics.gravity * rb.mass);

    }
}
