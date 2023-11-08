using Godot;

public partial class HealthBar : Range
{
	private PlayerCharacter characterInst { get { return PlayerCharacter.Instance; } }

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
