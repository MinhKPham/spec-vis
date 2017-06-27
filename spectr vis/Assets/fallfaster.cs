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
        if (rb.velocity.y < 10)
        {
            rb.AddForce(Physics.gravity * rb.mass * 40);
        }
        else rb.AddForce(Physics.gravity * rb.mass + new Vector3(0, -rb.velocity.y* rb.velocity.y*0.1f, 0));

    }
}
