using Godot;

public partial class EnemyCharacter : CharacterBody2D, IHealth
{
	[ExportCategory("Enemy Stats")]
	[Export]
	private float speed = 200f;
	[Export]
	private int payout = 5;

	[Export]
	public int MaxHealth { get; private set; }
	public float CurrHealth { get; private set; }

	private Vector2 PlayerPosition { get { return PlayerCharacter.Instance.GlobalPosition; } }
	private NavigationAgent2D navAgent;

	public override void _Ready()
	{
		if (MaxHealth <= 0)
		{
			GD.PrintErr(this.Name + " max health must be greater than 0.");
			Die();
		}
		CurrHealth = MaxHealth;

		int agentInd = 1;
		navAgent = GetChild<NavigationAgent2D>(agentInd);
		if(navAgent == null)
		{
			GD.PrintErr("NavAgent not found on '" + this.Name + "', did you move it from index " + agentInd + "?");
		}
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
		PlayerInventory.GetPaid(payout);
		WaveManager.EnemyKilled();
		this.QueueFree();
	}

	public override void _PhysicsProcess(double delta)
	{
		navAgent.TargetPosition = PlayerPosition;
		Vector2 nextPos = navAgent.GetNextPathPosition();
		LookTo(nextPos);
		this.Velocity = GetVelocity(nextPos);
		MoveAndSlide();
	}

	protected void LookTo(Vector2 pos)
	{
		this.LookAt(pos);
	}

	private Vector2 GetVelocity(Vector2 targetPos)
	{
		Vector2 newVelocity = (targetPos - this.GlobalPosition).Normalized() * speed;

		return newVelocity;
	}
}
