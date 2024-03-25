using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    private Rigidbody2D _rb;
    public EnemyMovement(Rigidbody2D rb)
    {
        _rb = rb;
    }
    
    public void Move( float speed, Transform point, Transform transform)
    {
        Vector2 direction = (point.position - transform.position).normalized;
        _rb.velocity = direction * speed * Time.deltaTime;
        Rotate(direction);

    }

    private void Rotate(Vector2 dir)
    {
        _rb.rotation = dir.x < 0 ? 0 : 180;
    }
}
