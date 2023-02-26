using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ChaseBehaviorTree : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // Opret en ny behavior tree knude for at bev�ge sig hen imod m�let
            MoveTowardsNode moveTowardsNode = new MoveTowardsNode(agent, target.position);
            // Evaluer behavior tree noden
            moveTowardsNode.Evaluate();
        }
    }
}
