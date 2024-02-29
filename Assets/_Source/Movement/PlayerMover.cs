using UnityEngine;
using System;
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float movementSpeed = 0.6f;
	[SerializeField] private float runningSpeedCoefficent = 1.5f;
	[SerializeField] private CapsuleCollider2D _capsuleCollider;
	[SerializeField] private float crouchingCoefficent = 0.8f;
	private Vector2 _movementVector;
	private float _capsuleColliderOffsetY;
	private float _capsuleColliderSizeY;
	public bool IsCrouching { get; private set; } = false;
	public bool IsMoving { get; private set; } = false;

	private void Start()
	{
		_capsuleColliderOffsetY = _capsuleCollider.offset.y;
		_capsuleColliderSizeY = _capsuleCollider.size.y;
	}
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
			IsMoving = true;

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
			IsMoving = false;
			rb.velocity = new Vector2(0, rb.velocity.y);

		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Crouch();
			// тут приседание на месте
		}

		if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			UnCrouch();
		}
	}
	private void Crouch()
	{
		IsCrouching = true;
		_capsuleCollider.size = new Vector2(_capsuleCollider.size.x, _capsuleCollider.size.y * crouchingCoefficent);
		_capsuleCollider.offset = new Vector2(_capsuleCollider.offset.x, _capsuleCollider.offset.x - (_capsuleColliderSizeY - _capsuleCollider.size.y) / 2);
	}
	private void UnCrouch()
	{
		IsCrouching = false;
		_capsuleCollider.size = new Vector2(_capsuleCollider.size.x, _capsuleColliderSizeY);
		_capsuleCollider.offset = new Vector2(_capsuleCollider.offset.x, _capsuleColliderOffsetY);

	}
}