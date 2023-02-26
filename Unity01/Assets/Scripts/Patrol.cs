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
        // Opret en ny behavior tree knude for at bevæge sig mod den næste patruljeposition
        MoveTowardsNode moveTowardsNode = new MoveTowardsNode(agent, waypoints[currentWaypoint].position);
        // Evaluer behavior tree noden
        moveTowardsNode.Evaluate();

        // Hvis agenten er tæt på patruljepositionen, skal han bevæge sig mod den næste position
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
