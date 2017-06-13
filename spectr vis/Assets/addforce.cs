using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour {

    // Use this for initialization
    public float force;
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "plat")
        {
            collision.rigidbody.AddForce(new Vector3(0, force*25, 0));
        }
        print("fffff");
    }
    void Update () {
		
	}
}
