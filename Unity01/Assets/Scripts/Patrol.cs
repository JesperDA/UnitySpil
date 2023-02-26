using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PatrolBehaviorTree : MonoBehaviour
{

    public Transform[] waypoints;
    int currentWaypoint = 0;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Opret en ny behavior tree knude for at bev�ge sig mod den n�ste patruljeposition
        MoveTowardsNode moveTowardsNode = new MoveTowardsNode(agent, waypoints[currentWaypoint].position);
        // Evaluer behavior tree noden
        moveTowardsNode.Evaluate();

        // Hvis agenten er t�t p� patruljepositionen, skal han bev�ge sig mod den n�ste position
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}
