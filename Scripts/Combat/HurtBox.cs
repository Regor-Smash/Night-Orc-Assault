using Godot;
using System;

[GlobalClass]
public partial class HurtBox : Area2D, IHealth
{
	[ExportCategory("HurtBox")]
	[Export]
	private int maxHealth;
	public int MaxHealth { get { return maxHealth; } }
	public float CurrHealth { get; private set; }

	public override void _Ready()
	{
		if (MaxHealth <= 0)
		{
			GD.PrintErr(this.Name + " health must be greater than 0.");
		}
		CurrHealth = MaxHealth;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void TakeDamage(float damage)
	{
		if(damage <= 0)
		{
			GD.PrintErr("Damage must be for a positive amount.");
			return;
		}
		GD.Print("OW");
		CurrHealth -= damage;

		if(CurrHealth <= 0)
		{
			Die();
		}
	}

	public void Heal(float amount)
	{
		if(amount <= 0)
		{
			GD.PrintErr("Healing must be for a positive amount.");
			return;
		}
		CurrHealth = Mathf.Clamp(CurrHealth + amount, 0f, MaxHealth);
	}

	private void Die()
	{
		GD.Print(this.Name + " dead");
		this.QueueFree();
	}
}
