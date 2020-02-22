using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    static float x = Const.sizeX;
    static float y = Const.sizeZ;
    static List<Vector2> path = new List<Vector2>();
    static List<Vector2> dir = new List<Vector2>() {
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(-1,0),
        new Vector2(1,0)
    };

    public static List<Vector2> GetNearPoints(Vector2 p)
    {
        List<Vector2> near = new List<Vector2>();
        foreach (Vector2 v in dir)
        {
            Vector2 n = p + v;
            if (InMap(n) && !InPath(n))
            {
                near.Add(n);
            }
        }
        return near;
    }

    static bool InMap(Vector2 p)
    {
        foreach (Vector2 r in Const.resources)
        {
            if (r == p)
            {
                return false;
            }
        }
        return p.x >= 0 && p.x <= x && p.y >= 0 && p.y <= y;
    }

    public static List<Vector2> GetPath(Vector2 from,Vector2 to)
    {
        path.Clear();
        path.Add(from);
        while (from != to)
        {
            Vector2 next = from;
            float min = x + y;
            foreach (Vector2 p in GetNearPoints(from))
            {
                float H = Vector2.Distance(p, from) + Vector2.Distance(p, to);
                if (H < min)
                {
                    min = H;
                    next = p;
                }
            }
            Debug.Log(next);
            path.Add(next);
            from = next;
        }
        return path;
    }

    static bool InPath(Vector2 p)
    {
        foreach(Vector2 v in path)
        {
            if (p == v)
            {
                return true;
            }
        }
        return false;
    }
}
