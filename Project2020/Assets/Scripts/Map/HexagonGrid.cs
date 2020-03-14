using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonGrid : MonoBehaviour
{
    public int x, y;
    static float g3 = Mathf.Sqrt(3);

    public static Vector2 Grid2Real(Vector2 v)
    {
        return Grid2Real(v.x, v.y);
    }
    public static Vector2 Grid2Real(float x, float y)
    {
        Vector2 v = new Vector2
        {
            x = x * 1.5f
        };
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

    public static Vector2 Real2Grid(float x,float y)
    {
        Vector2 v = new Vector2();
        v.x = Mathf.Floor(x / 1.5f + 0.5f);
        if (x % 2 == 0)
        {
            v.y = Mathf.Floor(y / g3 + 0.5f);
        }
        else
        {
            v.y = Mathf.Floor(y / g3);
        }
        return v;
    }
    private void Update()
    {
        Vector2 v = Grid2Real(x, y);
        transform.position = new Vector3(v.x, 0.1f, v.y);
    }
}
