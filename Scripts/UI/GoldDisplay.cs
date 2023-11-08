using Godot;

public partial class GoldDisplay : Label
{
	public override void _Process(double delta)
	{
		UpdateGoldValue();
	}

	private void UpdateGoldValue()
	{
		//Might add an animation
        this.Text = PlayerInventory.Gold.ToString();
    }
}
