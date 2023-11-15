using Godot;

[GlobalClass]
public partial class HurtBox : StaticBody2D, IHealth
{
	[ExportCategory("HurtBox")]
	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	public override void _Ready()
	{
		if (MaxHealth <= 0)
		{
			GD.PrintErr(this.Name + " max health must be greater than 0.");
			Die();
		}
		CurrHealth = MaxHealth;
	}

	public void TakeDamage(float amount)
	{
		if(amount <= 0)
		{
			GD.PrintErr("Damage must be for a positive amount.");
			return;
		}
		CurrHealth -= amount;

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
		//GD.Print(this.Name + " dead");
		this.QueueFree();
	}
}
