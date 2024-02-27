using UnityEngine;
using System;
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float movementSpeed = 0.6f;
	[SerializeField] private float runningSpeedCoefficent = 1.5f;
	private Vector2 _movementVector;

	void Update()
	{
		Move();
	}

	private void GetMovementVector()
	{
		_movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
	}

	public void Move()
	{
		GetMovementVector();
		if (MathF.Abs(_movementVector.x) > 0)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				rb.velocity = new Vector2(_movementVector.x * movementSpeed * runningSpeedCoefficent, rb.velocity.y);

			}
			else if (Input.GetKey(KeyCode.LeftControl))
			{
				rb.velocity = new Vector2(_movementVector.x * movementSpeed / 2, rb.velocity.y);
				// тут анимация ходьбы полуприсев

			}
			else
			{
				rb.velocity = new Vector2(_movementVector.x * movementSpeed, rb.velocity.y);

			}

		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
	}
}