using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayshooting : MonoBehaviour {

    // Use this for initialization

    Ray RayOrigin;
    RaycastHit HitInfo;
    RaycastHit hit;
    public GameObject target;
    public GameObject holder;
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    float time = 0;
    void Start () {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);

    }
    

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        Vector3 fwd = Camera.main.transform.forward;

        laserLineRenderer.enabled = false;
        if (Input.GetMouseButton(0) && time >= 0.1f)
        {
            time = 0;
            laserLineRenderer.enabled = true;
            if (true)
            {
                Vector3 from = target.transform.position;
                Vector3 to = holder.transform.position;
                Vector3 direction = to - from;
                

                
                
                   
                    //RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));
                if (Physics.Raycast(from, direction, out HitInfo))
                {
                    
                    Debug.DrawRay(target.transform.position, HitInfo.point - transform.position, Color.blue);
                        

                    laserLineRenderer.SetPosition(0, from);
                    laserLineRenderer.SetPosition(1, HitInfo.point);
                    print("hit");


                }
                else
                {


                    
                    laserLineRenderer.SetPosition(0, from);
                    laserLineRenderer.SetPosition(1, to);
                    print("hit");
                }




            }
            

        }

       
        else
        {
            laserLineRenderer.enabled = false;

        }


    }
}
