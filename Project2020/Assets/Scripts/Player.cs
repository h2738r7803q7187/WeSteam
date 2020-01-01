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
}
