using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 targetPos;
    public float smoothSpeed = 0.125f;
    Camera cam;

    Ray ray;
    RaycastHit hit;

    public static CamFollow instance;

    private void Start()
    {
        cam = GetComponent<Camera>();
        instance = this;
    }

    public void SetCamTarget()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            targetPos = hit.point;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            SetCamTarget();
        }


        if (Time.timeScale == 1)
        {
            Vector3 desiredPos = targetPos + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPos;



            //transform.LookAt(target.transform);



            //if (target.gameObject.GetComponent<Wheel>().hasEnded)
            //{
            //    smoothSpeed = 4;
            //}
        }
    }
}
