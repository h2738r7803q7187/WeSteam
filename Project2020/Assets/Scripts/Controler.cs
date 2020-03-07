using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Player Player;
    public Transform Ground;
    public Transform Building;
    public static int BuildingID = -1;
    void Start()
    {
        //Ground.transform.localScale = new Vector3(Const.sizeX, 0.1f, Const.sizeZ);
        //Ground.transform.position = new Vector3(Const.sizeX / 2, 0, Const.sizeZ / 2);
        Player.transform.localScale = new Vector3(Const.grid, 0.1f, Const.grid);
        Player.transform.position = new Vector3(Const.grid / 2, 0.01f, Const.grid / 2);
        transform.position = new Vector3(Const.startX, Const.grid * 5, Const.startZ);
        //Ground.GetComponent<MeshRenderer>().materials[0].mainTextureScale = new Vector2(Const.sizeX / Const.grid / 4, Const.sizeZ / Const.grid / 4);
        Ground.GetComponent<MeshRenderer>().materials[0].mainTextureScale = new Vector2(Ground.transform.localScale.x/4, Ground.transform.localScale.z/4);
        /*foreach (Vector2 p in Const.resources)
        {
            Transform t = Instantiate(Building);
            t.gameObject.SetActive(true);
            t.localScale = new Vector3(Const.grid, 0.1f, Const.grid);
            t.position = new Vector3((p.x + 0.5f) * Const.grid, 0.1f, (p.y + 0.5f) * Const.grid);
            Tools.SetImage3D(t, BuildingItem.path[0]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x, p.y - Input.GetAxis("Mouse ScrollWheel"), p.z);
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
                //GameObject gameObj = hitInfo.collider.gameObject;
                //int x = Mathf.FloorToInt(hitInfo.point.x / Const.grid);
                //int z = Mathf.FloorToInt(hitInfo.point.z / Const.grid);
                NavMeshPath path = new NavMeshPath();
                NavMeshAgent agent = Player.GetComponent<NavMeshAgent>();
                agent.CalculatePath(hitInfo.point,path);
                agent.SetPath(path);
                //Player.MoveToPos(x, z);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(BuildingID);
            Debug.Log(EventSystem.current.IsPointerOverGameObject());
            if (BuildingID < 0 || EventSystem.current.IsPointerOverGameObject()) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                int x = Mathf.FloorToInt(hitInfo.point.x / Const.grid);
                int z = Mathf.FloorToInt(hitInfo.point.z / Const.grid);
                Debug.Log("放置建筑" + BuildingID + "到" + x + "," + z);
                Transform t = Instantiate(Building);
                t.gameObject.SetActive(true);
                t.localScale = new Vector3(Const.grid, 0.1f, Const.grid);
                t.position = new Vector3((x + 0.5f) * Const.grid, 0.01f, (z + 0.5f) * Const.grid);
                Tools.SetImage3D(t, BuildingItem.path[BuildingID]);
                BuildingID = -1;
            }
        }
    }

}
