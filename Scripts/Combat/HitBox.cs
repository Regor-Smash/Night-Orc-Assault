using Godot;

[GlobalClass]
public partial class HitBox : Area2D
{
	[Export]
	private float damage;

	public override void _Ready()
	{
		this.BodyEntered += Hit; // detects PhysicsBody2D and TileMaps
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Hit(Node2D area)
	{
		GD.Print("Hit: " + area.Name);
		IHealth hurt = area as IHealth;
		if (hurt != null)
		{
			hurt.TakeDamage(damage);
		}
	}
}
