using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonMesh : MonoBehaviour
{
    Mesh mesh;
    public float radius;
    float g3 = Mathf.Sqrt(3);

    private void OnEnable()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.name = "正六边形";
        mesh.vertices = new Vector3[] {
            new Vector3(1, 0, 0),
            new Vector3(0.5f, 0, -g3/2),
            new Vector3(-0.5f, 0, -g3/2),
            new Vector3(-1, 0, 0),
            new Vector3(-0.5f, 0, g3/2),
            new Vector3(0.5f, 0, g3/2),
        };
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5 };
        mesh.uv = new Vector2[] {
            new Vector2(1,0.5f),
            new Vector2(0.75f,0.5f-g3/4),
            new Vector2(0.25f,0.5f-g3/4),
            new Vector2(0,0.5f),
            new Vector2(0.25f,0.5f+g3/4),
            new Vector2(0.75f,0.5f-g3/4)
        };
    }
}
