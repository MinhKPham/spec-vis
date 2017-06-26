using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayshooting : MonoBehaviour {

    // Use this for initialization

    Ray RayOrigin;
    RaycastHit HitInfo;
    RaycastHit hit;
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    void Start () {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);

    }
    

    // Update is called once per frame
    void Update () {
        Vector3 fwd = Camera.main.transform.forward;

        laserLineRenderer.enabled = false;
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
                    laserLineRenderer.enabled = true;
                    Debug.DrawRay(transform.position, HitInfo.point- transform.position, Color.blue);
                    print(hit.collider.gameObject.name+"=="+ HitInfo.collider.gameObject.name);

                    laserLineRenderer.SetPosition(0, from);
                    laserLineRenderer.SetPosition(1, HitInfo.point);
                    

                }


            }
            else
            {
                laserLineRenderer.enabled = false;
                
            }
        }
        

    }
}
