using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
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
    }
}
