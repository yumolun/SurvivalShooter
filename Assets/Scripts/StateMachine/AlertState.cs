using UnityEngine;
using System.Collections;
using System;

public class AlertState : IEnemyState
{
    private readonly StatePatternEnemy enemy;
    private float searchTimer;

    public AlertState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transit to same state");
    }

    public void ToChaseState()
    {
        enemy.CurrentState = enemy.ChaseState;
        searchTimer = 0f;
    }

    public void ToPatrolState()
    {
        enemy.CurrentState = enemy.PatrolState;
        searchTimer = 0f;
    }

    public void UpdateState()
    {
        Look();
        Search();
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

    private void Search()
    {
        enemy.MeshRendererFlag.material.color = Color.yellow;
        enemy.NavMeshAgent.Stop();
        enemy.transform.Rotate(0f, enemy.SearchingTurnSpeed * Time.deltaTime, 0f);

        searchTimer += Time.deltaTime;
        if(searchTimer >= enemy.SearchingDuration)
        {
            ToPatrolState();
        }
    }
}
