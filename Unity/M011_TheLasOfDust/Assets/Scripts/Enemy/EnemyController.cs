using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPatrolPoint;

    public Transform player;

    public UnityEngine.AI.NavMeshAgent agent;

    public float waitAtPoint = 2f;
    private float waitCounter;

    public float chaseRange = 8f;
    public float loseRange = 12f;

    public float attackRange = 1f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;


    public enum AIState
    {
        Idle,
        Patrol,
        Chasing,
        Attack,
        
    };
    public AIState currentState;

    void Start()
    {
        waitCounter = waitAtPoint;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case AIState.Idle:
                if (waitCounter > 0)
                { 
                    waitCounter -= Time.deltaTime; 
                }
                    else
                    {
                        currentState = AIState.Patrol;
                        agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                    }

                if(distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chasing;
                }

                    break;

            case AIState.Patrol:

                //agent.SetDestination(patrolPoints[currentPatrolPoint].position);

                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    //agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;
                }

                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chasing;
                }

                break;

            case AIState.Chasing:
                
                agent.SetDestination(player.position);

                if (distanceToPlayer <= attackRange)
                {
                    currentState = AIState.Attack;

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;
                }
                if (distanceToPlayer > loseRange)
                {
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;
                    agent.isStopped = false;
                }


                break;

            case AIState.Attack:

                transform.LookAt(player.position);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
               
                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    if(distanceToPlayer < attackRange)
                    {
                        attackCounter = timeBetweenAttacks;
                    }
                    else
                    {
                        currentState = AIState.Idle;
                        waitCounter = waitAtPoint;

                        agent.isStopped = false;
                    }
                }
                
                break;
        }
        
    }
}
