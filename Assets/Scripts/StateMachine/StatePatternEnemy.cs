using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{

    public float SearchingTurnSpeed = 120f;
    public float SearchingDuration = 4f;
    public float SightRange = 20f;
    public Transform Eyes;
    public Vector3 Offset = new Vector3(0, 0.5f, 0);
    public MeshRenderer MeshRendererFlag;

    [HideInInspector]
    public Transform ChaseTarget;

    [HideInInspector]
    public IEnemyState CurrentState;

    [HideInInspector]
    public PatrolState PatrolState;

    [HideInInspector]
    public AlertState AlertState;

    [HideInInspector]
    public ChaseState ChaseState;

    [HideInInspector]
    public NavMeshAgent NavMeshAgent;

    [HideInInspector]
    public Transform[] wayPoints;

    private EnemyManager enemyManger;

    private void Awake()
    {
        PatrolState = new PatrolState(this);
        AlertState = new AlertState(this);
        ChaseState = new ChaseState(this);
        NavMeshAgent = GetComponent<NavMeshAgent>();
        enemyManger = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        /*
        wayPoints = new Transform[enemyManger.wayPoints.Length];
        for (int i = 0; i < enemyManger.wayPoints.Length; i++)
        {
            wayPoints[i] = enemyManger.wayPoints[i];
        }
        */
    }

    private void Start()
    {
        CurrentState = PatrolState;
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }
}
