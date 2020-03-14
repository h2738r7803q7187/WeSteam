using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMesh : MonoBehaviour
{
    Mesh mesh1, mesh2, mesh3;
    public Texture t1, t2, t3;
    Transform child1, child2, child3;
    readonly int[] triangles = new int[] { 0, 2, 1, 1, 2, 3 };

    void Start()
    {
        child1 = transform.GetChild(0);
        child2 = transform.GetChild(1);
        child3 = transform.GetChild(2);
        mesh1 = child1.GetComponent<MeshFilter>().mesh;
        mesh2 = child2.GetComponent<MeshFilter>().mesh;
        mesh3 = child3.GetComponent<MeshFilter>().mesh;
        mesh1.vertices = new Vector3[]
        {
            new Vector3(0,0,0.67f),
            new Vector3(1,0,0.67f),
            new Vector3(0,0,1),
            new Vector3(1,0,1),
        };
        mesh2.vertices = new Vector3[]
        {
            new Vector3(0,0,0.33f),
            new Vector3(1,0,0.33f),
            new Vector3(0,0,0.67f),
            new Vector3(1,0,0.67f),
        };
        mesh3.vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(1,0,0),
            new Vector3(0,0,0.33f),
            new Vector3(1,0,0.33f),
        };
        mesh1.triangles = triangles;
        mesh2.triangles = triangles;
        mesh3.triangles = triangles;
        mesh1.uv = new Vector2[]{
            new Vector2(0,0.67f),
            new Vector2(1,0.67f),
            new Vector2(0,1),
            new Vector2(1,1),
        };
        mesh2.uv = new Vector2[]{
            new Vector2(0,0.33f),
            new Vector2(1,0.33f),
            new Vector2(0,0.67f),
            new Vector2(1,0.67f),
        };
        mesh3.uv = new Vector2[]{
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0.33f),
            new Vector2(1,0.33f),
        };
    }

    void Update()
    {
        SetTex();
    }

    void SetTex()
    {
        child1.GetComponent<MeshRenderer>().material.mainTexture = t1;
        child2.GetComponent<MeshRenderer>().material.mainTexture = t2;
        child3.GetComponent<MeshRenderer>().material.mainTexture = t3;
    }
}
