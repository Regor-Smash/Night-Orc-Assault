using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export]
	private float speed = 200f;

	public override void _PhysicsProcess(double delta)
	{
		LookTo();
		this.Velocity = GetVelocity();
		MoveAndSlide();
	}

	private void LookTo()
	{
		Vector2 playerPos = PlayerMove.Instance.Position;

		this.LookAt(playerPos);
	}

	private Vector2 GetVelocity()
	{
		//Move directly toward player
		Vector2 playerPos = PlayerMove.Instance.Position;
		Vector2 newVelocity = (playerPos - this.Position).Normalized() * speed;

		return newVelocity;
	}
}
