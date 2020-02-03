using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget,
    }
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private EnemyPathfindingMovement pathfindingMovement;
    private Shooting shoot;
    [SerializeField]
    float randomMovementRangeX = 10f, randomMovementRangeY = 70f;
    public float targetRange = 9;
    public float attackRange = 3;
    private State state;
    bool isAlive = true;

    private void Awake()
    {
        pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        shoot = GetComponent<Shooting>();
        state = State.Roaming;
    }

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    public void Update()
    {
        if (GameManager.Instance.IsGamePaused())
        {
            return;
        }

        switch (state)
        {
            default:
            case State.Roaming:
                pathfindingMovement.MoveToTimer(roamPosition);

                float reachedPositionDistance = 1f;
                if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
                {
                    roamPosition = GetRoamingPosition();
                }
                FindTarget();
                break;
            case State.ChaseTarget:
                pathfindingMovement.MoveToTimer(PlayerManager.Instance.GetPlayerPosition());
                if(Vector3.Distance(transform.position,PlayerManager.Instance.GetPlayerPosition()) < attackRange)
                {
                    pathfindingMovement.StopMoving();
                    shoot.FireWeapon((PlayerManager.Instance.GetPlayerPosition()- transform.position));
                }
                break;
        }
        
    }

    private Vector3 GetRoamingPosition()
    {
       return startingPosition + GetRandomDir() * Random.Range(randomMovementRangeX, randomMovementRangeY);
    }

    //code monkey:lta pöllitty...korjaan lainattu. EnemyAI video 8.1.2020
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void  FindTarget()
    {
       if(Vector3.Distance(transform.position, PlayerManager.Instance.GetPlayerPosition()) < targetRange)
        {
            state = State.ChaseTarget;
        }
    }
}
