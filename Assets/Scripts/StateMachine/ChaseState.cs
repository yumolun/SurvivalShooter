using UnityEngine;
using System.Collections;
using System;

public class ChaseState : IEnemyState
{
    private readonly StatePatternEnemy enemy;

    public ChaseState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void ToAlertState()
    {
        enemy.CurrentState = enemy.AlertState;
    }

    public void ToChaseState()
    {
        Debug.Log("Can't transit to same state");
    }

    public void ToPatrolState()
    {
        throw new NotImplementedException();
    }

    public void UpdateState()
    {
        Look();
        Chase();
    }

    private void Look()
    {
        Vector3 enemyToTarget = enemy.ChaseTarget.position + enemy.Offset - enemy.Eyes.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(enemy.Eyes.position, enemyToTarget, out hit, enemy.SightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.ChaseTarget = hit.transform;
        }
        else
        {
            ToAlertState();
        }
    }

    private void Chase()
    {
        enemy.MeshRendererFlag.material.color = Color.red;
        enemy.NavMeshAgent.destination = enemy.ChaseTarget.position;
        enemy.NavMeshAgent.Resume();
    }
}
