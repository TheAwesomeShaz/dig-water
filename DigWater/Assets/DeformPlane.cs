using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    MeshFilter meshFilter;
    Mesh planeMesh;

   

    Vector3[] verts;
    [SerializeField] float radius;
    [SerializeField] float power;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        planeMesh = meshFilter.mesh;
        verts = planeMesh.vertices;
    }
    public void DeformThisPlane(Vector3 positionToDeform)
    {
        positionToDeform = transform.InverseTransformPoint(positionToDeform);

        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - positionToDeform).sqrMagnitude;
            if (dist < radius)
            {
                verts[i] -= Vector3.up * power;
            }

        }
        planeMesh.vertices = verts;

    }
}
