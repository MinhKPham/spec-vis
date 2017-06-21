using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayshooting : MonoBehaviour {

    // Use this for initialization

    Ray RayOrigin;
    RaycastHit HitInfo;
    RaycastHit hit;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = Camera.main.transform.forward;
        
        
        if (Physics.Raycast(Camera.main.transform.position, fwd, out hit))
        {
            Vector3 from = transform.position;
            Vector3 to = hit.point;
            Vector3 direction = to - from;
            Debug.DrawRay(Camera.main.transform.position, direction, Color.green);
            
            if (Input.GetKey(KeyCode.E))
            {
                //RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));
                if (Physics.Raycast(from,direction, out HitInfo))
                {
                    Debug.DrawRay(transform.position, HitInfo.point- transform.position, Color.blue);
                    print(hit.collider.gameObject.name+"=="+ HitInfo.collider.gameObject.name);


                }


            }
        }
        

    }
}
