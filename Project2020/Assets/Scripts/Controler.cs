using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Player Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            Player.MoveUp();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Player.MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Player.MoveDown();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Player.MoveRight();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                int x = Mathf.FloorToInt(hitInfo.point.x / 10);
                int z = Mathf.FloorToInt(hitInfo.point.z / 10);
                Player.MoveToPos(x, z);
            }
        }

    }
}
