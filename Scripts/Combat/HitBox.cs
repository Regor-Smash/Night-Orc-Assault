using Godot;
using System;

[GlobalClass]
public partial class HitBox : Area2D
{
	[Export]
	private float damage;

	public override void _Ready()
	{
		this.AreaEntered += Hit;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Hit(Area2D area)
	{
		HurtBox hurt = area as HurtBox;
		if (hurt != null)
		{
			hurt.TakeDamage(damage);
		}
	}
}
