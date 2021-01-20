using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public static RaycastCam instance;
    Camera cam;
    [SerializeField] Transform ringPrefab;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cam = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DeformMesh();
        }
    }

    private void DeformMesh()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            

            //Deform Mesh
            DeformPlane deformPlane = hit.transform.GetComponent<DeformPlane>();
            deformPlane.DeformThisPlane(hit.point);

            Instantiate(ringPrefab, hit.point,  Quaternion.Euler(-90,0,0));
        }
    }
}
