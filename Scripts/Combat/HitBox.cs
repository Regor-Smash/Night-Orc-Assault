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

	private void Hit(Node2D area)
	{
		//GD.Print(this.Name + " hit: " + area.Name);
		IHealth hurt = area as IHealth;
		if (hurt != null)
		{
			hurt.TakeDamage(damage);
		}
	}
}
