using Godot;
using System;

public partial class Enemy : CharacterBody2D, IHealth
{
	[ExportCategory("Stats")]
	[Export]
	private float speed = 200f;

	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	public override void _Ready()
	{
		if (MaxHealth <= 0)
		{
			GD.PrintErr("Enemy health must be greater than 0.");
		}
		CurrHealth = MaxHealth;
	}

	public void TakeDamage (float amount)
	{
		CurrHealth -= amount;
		if(CurrHealth <= 0)
		{
			Die();
		}
	}

	public void Heal (float amount)
	{
		CurrHealth += amount;
		if (CurrHealth > MaxHealth) { CurrHealth = MaxHealth; }
	}

	private void Die()
	{
		GD.Print("Enemy dead");
		this.QueueFree();
	}

	public override void _PhysicsProcess(double delta)
	{
		TakeDamage(1);
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
