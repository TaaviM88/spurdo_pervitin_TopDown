using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfindingMovement : MonoBehaviour
{
    public float speed = 1f;
    //private EnemyMain enemyMain;
    private Enemy enemy;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathfindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGamePaused())
        {
            return;
        }
        pathfindingTimer -= Time.deltaTime;
        HandleMovement();
    }

    void FixedUpdate()
    {
        //enemy._rb2d.velocity = moveDir * speed;
        if (GameManager.Instance.IsGamePaused())
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
    }

    private void HandleMovement()
    {
        
    }

    public void MoveTo(Vector3 targetPosition)
    {
        SetTargetPosition(targetPosition);
    }

    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }

    public void MoveToTimer(Vector3 targetPosition)
    {
        if(pathfindingTimer <= 0f)
        {
            SetTargetPosition(targetPosition);
        }
    }

    private void SetTargetPosition(Vector3 targetPosition)
    {
        moveDir = (Vector2)targetPosition;
        //moveDir = (this.transform.position - targetPosition).normalized;
    }
}
