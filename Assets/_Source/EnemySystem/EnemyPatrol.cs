using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private bool isPatrolling;
    [SerializeField] private List<Transform> destinationPoints;
    [SerializeField] private float timeOnStop;
    [SerializeField] private Enemy enemy;
    private EnemyMovement _enemyMovement;
    private int _currPoint;
    private bool _isOnStop;

    private void Start()
    {
        _enemyMovement = new EnemyMovement(enemy.Rb);
        _currPoint = 0;
        _isOnStop = false;
    }

    private void Update()
    {
        if (isPatrolling)
        {
            FindDistance();

        }

        if (_isOnStop)
        {
            StartCoroutine(OnStop());
        }

    }

    private void FixedUpdate()
    {
        if(isPatrolling)
            _enemyMovement.Move(enemy.Speed,destinationPoints[_currPoint],transform);
    }

    private void FindDistance()
    {
        //Debug.Log(Vector2.Distance(destinationPoints[_currPoint].position, transform.position));
        if (Vector2.Distance(destinationPoints[_currPoint].position, transform.position) <= 0.3f)
        {
            if (_currPoint < destinationPoints.Count)
            {
                _isOnStop = true;
                if (_currPoint == destinationPoints.Count - 1)
                {
                    _currPoint = -1;
                }
                _currPoint++;
            }

        }
    }

    IEnumerator OnStop()
    {
        _isOnStop = false;
        isPatrolling = false;
        yield return new WaitForSeconds(timeOnStop);
        isPatrolling = true;
    }
    
        
    
    

   


}
