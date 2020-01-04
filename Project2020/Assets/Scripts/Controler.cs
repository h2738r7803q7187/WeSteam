﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Player Player;
    public Transform Ground;
    public static int BuildingID = 0;
    void Start()
    {
        Ground.transform.localScale = new Vector3(Const.sizeX, 0.1f, Const.sizeZ);
        Ground.transform.position = new Vector3(Const.sizeX / 2, 0, Const.sizeZ / 2);
        Player.transform.localScale = new Vector3(Const.grid, 0.1f, Const.grid);
        Player.transform.position = new Vector3(Const.grid / 2, 0.01f, Const.grid / 2);
        transform.position = new Vector3(Const.startX, Const.grid * 5, Const.startZ);
        Ground.GetComponent<MeshRenderer>().materials[0].mainTextureScale = new Vector2(Const.sizeX / Const.grid / 4, Const.sizeZ / Const.grid / 4);
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z + Const.grid / 10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z - Const.grid / 10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x - Const.grid / 10,
                transform.localPosition.y,
                transform.localPosition.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x + Const.grid / 10,
                transform.localPosition.y,
                transform.localPosition.z);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                int x = Mathf.FloorToInt(hitInfo.point.x / Const.grid);
                int z = Mathf.FloorToInt(hitInfo.point.z / Const.grid);
                Player.MoveToPos(x, z);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (BuildingID == 0) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                int x = Mathf.FloorToInt(hitInfo.point.x / Const.grid);
                int z = Mathf.FloorToInt(hitInfo.point.z / Const.grid);
                Debug.Log("放置建筑" + BuildingID + "到" + x + "," + z);
            }
        }
    }

}
