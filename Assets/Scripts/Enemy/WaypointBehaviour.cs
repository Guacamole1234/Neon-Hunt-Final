using UnityEngine;
using UnityEngine.AI;

public class WaypointBehaviour : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] waypoints;

    int currentWaypoint;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void Update()
    {
        if (GeneralController.instance.gameActive)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                GoToNextWaypoint();
            }
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
    }

    void GoToNextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
    }
}
