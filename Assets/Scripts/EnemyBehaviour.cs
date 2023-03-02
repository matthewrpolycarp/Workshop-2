using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Vector3[] patrolPoints;
    public float chaseRange;

    private int currentPatrolIndex;
    private Transform player;
    private bool isChasing;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    void Chase()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolIndex], Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex]) < 1f)
        {
            currentPatrolIndex++;

            if (currentPatrolIndex >= patrolPoints.Length)
            {
                currentPatrolIndex = 0;
            }
        }
    }
}
