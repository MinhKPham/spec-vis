using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayshooting : MonoBehaviour {

    // Use this for initialization

    Ray RayOrigin;
    RaycastHit HitInfo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));
            if (Physics.Raycast(RayOrigin, out HitInfo, 100f))
            {
                Debug.DrawRay(RayOrigin.direction, HitInfo.point, Color.yellow);
            }
        }
    }
}
