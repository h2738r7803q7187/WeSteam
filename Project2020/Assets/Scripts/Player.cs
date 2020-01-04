using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MoveUp()
    {
        if (transform.localPosition.z >= Const.maxZ) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Const.grid);
    }
    public void MoveDown()
    {
        if (transform.localPosition.z <= Const.minZ) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - Const.grid);
    }

    public void MoveLeft()
    {
        if (transform.localPosition.x <= Const.maxX) return;
        transform.localPosition = new Vector3(transform.localPosition.x - Const.grid, transform.localPosition.y, transform.localPosition.z);
    }

    public void MoveRight()
    {
        if (transform.localPosition.x >= Const.maxX) return;
        transform.localPosition = new Vector3(transform.localPosition.x + Const.grid, transform.localPosition.y, transform.localPosition.z);
    }

    public void MoveToPos(int x, int z)
    {
        Debug.Log("移动到坐标" + x + "," + z);
        int deltax = x - Mathf.FloorToInt(transform.localPosition.x / Const.grid);
        int deltaz = z - Mathf.FloorToInt(transform.localPosition.z / Const.grid);
        StartCoroutine(Move(deltax, deltaz));
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
