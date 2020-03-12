using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonGrid : MonoBehaviour
{
    public int x, y;
    float g3 = Mathf.Sqrt(3);

    Vector2 Grid2Real(int x, int y)
    {
        Vector2 v = new Vector2();
        v.x = x * 1.5f;
        if (x % 2 == 0)
        {
            v.y = y * g3;
        }
        else
        {
            v.y = (y + 0.5f) * g3;
        }
        return v;
    }

    private void Update()
    {
        Vector2 v = Grid2Real(x, y);
        transform.position = new Vector3(v.x, 0.1f, v.y);
    }
}
