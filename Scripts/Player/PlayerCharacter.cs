using Godot;

public partial class PlayerCharacter : CharacterBody2D, IHealth
{
	[ExportCategory("Stats")]
	[Export]
	private float speed = 400f;
	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	[ExportCategory("Refs")]
	[Export]
	private AnimationPlayer anim;

	public static PlayerCharacter Instance { get; private set; }

	public override void _Ready()
	{
		//Singleton
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			GD.PrintErr("There are two players");
		}

		//IHealth
		if (MaxHealth <= 0)
		{
			GD.PrintErr("Player health must be greater than 0.");
		}
		CurrHealth = MaxHealth;
		WaveManager.EndWave += WaveHeal;

		//Animation
		if (!IsInstanceValid(anim))
		{
			GD.PrintErr("No animation player");
		}
	}

	public void TakeDamage(float amount)
	{
		if (amount <= 0)
		{
			GD.PrintErr("Damage must be for a positive amount.");
			return;
		}

		CurrHealth -= amount;
		GD.Print("Player took damage.");
		if (CurrHealth <= 0)
		{
			Die();
		}
	}

	public void Heal(float amount)
	{
		if (amount <= 0)
		{
			GD.PrintErr("Healing must be for a positive amount.");
			return;
		}

		CurrHealth = Mathf.Clamp(CurrHealth + amount, 0f, MaxHealth);
	}

	private void WaveHeal (int wave)
	{
		Heal(10000);
	}

	public float GetHealthPercent()
	{
		return Mathf.Clamp(CurrHealth, 0, MaxHealth) / MaxHealth;
	}

	private void Die()
	{
		GD.Print("Player dead");
		//Game Over.exe
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 newVelocity = Vector2.Zero;

		// Get the input direction
		Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
		if (direction != Vector2.Zero)
		{
			//If moving, set velocity
			newVelocity = direction * speed;
			//GD.Print(direction + " * " + speed + " = " + newVelocity);
		}

		this.Velocity = newVelocity;
		MoveAndSlide();
	}

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
		anim.Play(name: "basic attack");
	}

	public override void _ExitTree()
	{
		if (Instance == this) { Instance = null; }
	}
}
