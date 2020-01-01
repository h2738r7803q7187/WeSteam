using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MoveUp()
    {
        if (transform.localPosition.y >= 400) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 100);
    }
    public void MoveDown()
    {
        if (transform.localPosition.y <= -500) return;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 100);
    }

    public void MoveLeft()
    {
        if (transform.localPosition.x <= -500) return;
        transform.localPosition = new Vector3(transform.localPosition.x - 100, transform.localPosition.y);
    }

    public void MoveRight()
    {
        if (transform.localPosition.x >= 400) return;
        transform.localPosition = new Vector3(transform.localPosition.x + 100, transform.localPosition.y);
    }

    public void MoveToPos(int x,int y)
    {
        int deltax = x-Mathf.FloorToInt((transform.localPosition.x+500) / 100);
        int deltay = y-Mathf.FloorToInt((transform.localPosition.y+500) / 100);
        StartCoroutine(Move(deltax, deltay));
    }

    IEnumerator Move(int x,int y)
    {
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

        if (y > 0)
        {
            for (int i = 0; i < y; i++)
            {
                MoveUp();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < -y; i++)
            {
                MoveDown();
                yield return new WaitForSeconds(0.5f);
            }
        }
        
    }
}
