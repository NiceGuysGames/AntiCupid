using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float radius;
    [Range(0, 360)] [SerializeField] private float angle;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obsMask;
    private  bool _canSeePlayer; 
    public GameObject Player { get; private set; }

   

    void Update()
    {
        if(_canSeePlayer)
            Debug.Log("Detect player");
       
        FieldOfViewCheck();
    }
    
    
    public  void FieldOfViewCheck()
    {
        Collider2D rangeCheck = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), radius, targetMask);

        if (rangeCheck != null)
        {
            Transform target = rangeCheck.transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(-transform.right, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obsMask))
                    SeePlayer(true, target.gameObject);
                        
                    
                else
                    SeePlayer(false);
            }
            else
                SeePlayer(false);

        }
        /*else if (_canSeePlayer)
        {
            SeePlayer(false);
        }*/
    }



    
    public void SeePlayer(bool see, GameObject player = null)
    {
        _canSeePlayer = see;
        
        
        Player = player;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position - DirectionFromAngle(-transform.eulerAngles.z, -angle / 2) * radius);
        Gizmos.DrawLine(transform.position, transform.position - DirectionFromAngle(-transform.eulerAngles.z, angle / 2) * radius);

           
    }
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
    }

}
