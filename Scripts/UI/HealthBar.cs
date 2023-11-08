using Godot;

public partial class HealthBar : Range
{
	private PlayerCharacter characterInst { get { return PlayerCharacter.Instance; } }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateHealthValues();
	}

	private void UpdateHealthValues()
	{
		this.MaxValue = characterInst.MaxHealth;
		this.Value = characterInst.CurrHealth;
	}
}
