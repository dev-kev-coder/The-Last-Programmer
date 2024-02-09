using Godot;
using System;

public class Player : KinematicBody2D
{
	private Vector2 _velocity = new Vector2();
	private float _gravity = 1200f;
	private float _walkSpeed = 200f;
	private float _jumpSpeed = -500f;

	public override void _PhysicsProcess(float delta)
	{
		_velocity.y += _gravity * delta;

		// Reset horizontal velocity
		_velocity.x = 0;

		// Handling left and right movement
		if (Input.IsActionPressed("ui_right"))
		{
			_velocity.x += _walkSpeed;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			_velocity.x -= _walkSpeed;
		}

		// Jumping
		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			_velocity.y = _jumpSpeed;
		}

		// Move the character and check for collisions
		_velocity = MoveAndSlide(_velocity, Vector2.Up);
	}
}
