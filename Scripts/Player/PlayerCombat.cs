using Godot;
using System;

public partial class PlayerCombat : Node2D, IHealth
{
	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	[Export]
	private AnimationPlayer anim;

	public override void _Ready()
    {
        if (MaxHealth <= 0)
        {
            GD.PrintErr("Player health must be greater than 0.");
        }
        CurrHealth = MaxHealth;

		if (!IsInstanceValid(anim))
		{
			GD.PrintErr("No animation player");
		}
	}

	public void TakeDamage(float amount)
	{
		CurrHealth -= amount;
		if (CurrHealth <= 0)
		{
			Die();
		}
	}

	public void Heal(float amount)
	{
		CurrHealth += amount;
		if (CurrHealth > MaxHealth) { CurrHealth = MaxHealth; }
	}

	private void Die()
	{
		GD.Print("Player dead");
		//Game Over.exe
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Attack"))
		{
			Attack();
		}
	}

	private void Attack()
	{
		GD.Print("Player attacked");
		anim.Play(name:"basic attack");
	}
}
