using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackBehaviorTree : MonoBehaviour
{

    public Transform target;
    public float attackDistance = 2f;
    public float attackCooldown = 1f;
    float lastAttackTime = 0f;
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

            // Hvis agenten er t�t nok p� m�let, skal han angribe
            if (Vector3.Distance(transform.position, target.position) < attackDistance)
            {
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    // Opret en ny behavior tree knude for at angribe m�let
                    AttackNode attackNode = new AttackNode();
                    // Evaluer behavior tree noden
                    attackNode.Evaluate();
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}

// AttackNode klassen implementerer en action-leaf i Behavior Tree, der udf�rer angrebslogikken
public class AttackNode
{

    public void Evaluate()
    {
        // Implementer