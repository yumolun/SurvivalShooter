using UnityEngine;

public class PatrolState : IEnemyState
{
    private readonly StatePatternEnemy enemy;
    private int nextWayPoint;

    public PatrolState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ToAlertState();
        }
    }

    public void ToAlertState()
    {
        enemy.CurrentState = enemy.AlertState;
    }

    public void ToChaseState()
    {
        enemy.CurrentState = enemy.ChaseState;
    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transit to same state");
    }

    public void UpdateState()
    {
        Look();
        Patrol();
    }

    private void Look()
    {
        RaycastHit hit;

        if (Physics.Raycast(enemy.Eyes.position, enemy.Eyes.forward, out hit, enemy.SightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.ChaseTarget = hit.transform;
            ToChaseState();
        }
    }

    private void Patrol()
    {
        enemy.MeshRendererFlag.material.color = Color.green;
        enemy.NavMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.NavMeshAgent.Resume();

        if(enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance && !enemy.NavMeshAgent.pathPending)
        {
            nextWayPoint = Random.Range(0, enemy.wayPoints.Length);
        }
    }
}
