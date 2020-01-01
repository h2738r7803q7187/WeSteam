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
        if (Input.GetMouseButtonUp(0))
        {
            int x = Mathf.FloorToInt(Input.mousePosition.x / 100);
            int y = Mathf.FloorToInt(Input.mousePosition.y / 100);
            Player.MoveToPos(x, y);
        }
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
    }
}
