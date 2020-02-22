using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MoveUp()
    {
        if (transform.localPosition.z >= Const.maxZ) return;
        if (!canGO(transform.localPosition.x, transform.localPosition.z + 1)) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Const.grid);
    }
    public void MoveDown()
    {
        if (transform.localPosition.z <= Const.minZ) return;
        if (!canGO(transform.localPosition.x, transform.localPosition.z - 1)) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - Const.grid);
    }

    public void MoveLeft()
    {
        if (transform.localPosition.x <= Const.minX) return;
        if (!canGO(transform.localPosition.x - 1, transform.localPosition.z)) return;
        transform.localPosition = new Vector3(transform.localPosition.x - Const.grid, transform.localPosition.y, transform.localPosition.z);
    }

    public void MoveRight()
    {
        if (transform.localPosition.x >= Const.maxX) return;
        if (!canGO(transform.localPosition.x + 1, transform.localPosition.z)) return;
        transform.localPosition = new Vector3(transform.localPosition.x + Const.grid, transform.localPosition.y, transform.localPosition.z);
    }

    public void MoveToPos(int x, int z)
    {
        Debug.Log("移动到坐标" + x + "," + z);
        List<Vector2> path = PathFind.GetPath(new Vector2(Mathf.FloorToInt(transform.localPosition.x / Const.grid),
            Mathf.FloorToInt(transform.localPosition.z / Const.grid)), new Vector2(x, z));
        float time = 0;
        foreach(Vector2 v in path)
        {
            StartCoroutine(SetPos(v.x, v.y, time));
            time += 0.5f;
        }
        //int deltax = x - Mathf.FloorToInt(transform.localPosition.x / Const.grid);
        //int deltaz = z - Mathf.FloorToInt(transform.localPosition.z / Const.grid);
        //StartCoroutine(Move(deltax, deltaz));
    }

    //是否可以走
    bool canGO(float x, float y)
    {
        bool canGO = true;
        foreach (Vector2 p in Const.resources)
        {
            if (x - 0.5 == p.x && y - 0.5 == p.y)
            {
                canGO = false;
            }
        }
        return canGO;
    }


    IEnumerator SetPos(float x, float z,float time)
    {
        yield return new WaitForSeconds(time);
        transform.localPosition = new Vector3(x + 0.5f, transform.localPosition.y, z + 0.5f);
    }
    IEnumerator Move(int x, int z)
    {
        Debug.Log("距离" + x + "," + z);
        if (x > 0)
        {
            for (int i = 0; i < x; i++)
            {
                MoveRight();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < -x; i++)
            {
                MoveLeft();
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (z > 0)
        {
            for (int i = 0; i < z; i++)
            {
                MoveUp();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < -z; i++)
            {
                MoveDown();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
