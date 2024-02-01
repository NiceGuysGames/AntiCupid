using UnityEngine;
using System;
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float movementSpeed = 0.6f;
	[SerializeField] private float runningSpeedCoefficent = 1.5f;
	private Vector2 movementVector;

	private void GetMovementVector()
	{
		movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
	}

	public void Move()
	{
		GetMovementVector();
		if (MathF.Abs(movementVector.x) > 0)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				rb.velocity = movementVector * movementSpeed * runningSpeedCoefficent;

			}
			else
			{
				rb.velocity = movementVector * movementSpeed;
			}

		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}
	// void Start()
	// {
	// rb = GetComponent<Rigidbody2D>();
	// }
	void Update()
	{
		Move();
	}

}