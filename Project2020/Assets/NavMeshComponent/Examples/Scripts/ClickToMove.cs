using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    public Transform Building;
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                Vector2 grid = HexagonGrid.Real2Grid(m_HitInfo.point.x, m_HitInfo.point.z);
                Debug.Log(grid);
                Vector2 pos = HexagonGrid.Grid2Real(grid);
                m_Agent.destination = new Vector3(pos.x, 0.1f, pos.y);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            int BuildingID = Controler.BuildingID;
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
                t.name = "建筑" + BuildingID;
                t.gameObject.SetActive(true);
                t.localScale = new Vector3(Const.grid, 0.1f, Const.grid);
                t.position = new Vector3((x + 0.5f) * Const.grid, 0.01f, (z + 0.5f) * Const.grid);
                Tools.SetImage3D(t, BuildingItem.path[BuildingID]);
                BuildingID = -1;
            }
        }
    }
}
