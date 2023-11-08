using Godot;

public partial class EnemyCharacter : CharacterBody2D, IHealth
{
	[ExportCategory("Enemy Stats")]
	[Export]
	private float speed = 200f;

	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	private Vector2 PlayerPosition { get { return PlayerCharacter.Instance.GlobalPosition; } }

	public override void _Ready()
	{
		if (MaxHealth <= 0)
		{
			GD.PrintErr(this.Name + " max health must be greater than 0.");
			Die();
		}
		CurrHealth = MaxHealth;
	}

	public void TakeDamage (float amount)
	{
		if (amount <= 0)
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

	public void Heal (float amount)
	{
		if (amount <= 0)
		{
			GD.PrintErr("Healing must be for a positive amount.");
			return;
		}
		CurrHealth = Mathf.Clamp(CurrHealth + amount, 0f, MaxHealth);
	}

	private void Die()
	{
		GD.Print("Enemy dead");
		this.QueueFree();
	}

	public override void _PhysicsProcess(double delta)
	{
		LookTo();
		this.Velocity = GetVelocity();
		MoveAndSlide();
	}

	private void LookTo()
	{
		Vector2 playerPos = PlayerPosition;

		this.LookAt(playerPos);
	}

	private Vector2 GetVelocity()
	{
		//Move directly toward player
		Vector2 playerPos = PlayerPosition;
		Vector2 newVelocity = (playerPos - this.GlobalPosition).Normalized() * speed;

		return newVelocity;
	}
}
