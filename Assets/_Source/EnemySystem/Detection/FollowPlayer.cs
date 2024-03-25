using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speedOfFollowing;
    [SerializeField] private PlayerDetector playerDetector; 
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _moveTo;
    private float _time;
    public bool IsDetected { get; private set; }
    private bool _startedMoving;

    void Start()
    {
        IsDetected = false;
      
    }
    private void Update()
    {
        Detection();
    }
    private void FixedUpdate()
    {
        if (IsDetected || _startedMoving)
        {
            MoveToPlayer();
            _startedMoving = true;

        }

        if (_startedMoving && !IsDetected)
        {
            StartCoroutine(StopMoving());

        }


    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(1.5f);
        _startedMoving = false;
    }
    private void Detection()
    {
        if (playerDetector.Player)
            IsDetected = true;

        else
            IsDetected = false;




    }
       
    private void MoveToPlayer()
    {
        _moveTo = (player.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.position + _moveTo * speedOfFollowing * Time.fixedDeltaTime);
    }
}
