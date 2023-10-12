using Godot;
using System;

public partial class PlayerMove : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 newVelocity = this.Velocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
		if (direction != Vector2.Zero)
		{
			newVelocity.X = direction.X * Speed;
			newVelocity.Y = direction.Y * Speed;
		}
		else
		{
			newVelocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			newVelocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		this.Velocity = newVelocity;
		MoveAndSlide();
	}
}
