using Godot;

public partial class EndWaveScreen : Control
{
	[Export]
	private Button continueButton;
	public override void _Ready()
	{
		this.ProcessMode = ProcessModeEnum.Always;
		
		WaveManager.EndWave += EndOfWave;
		continueButton.ButtonUp += Continue;
	}

	public override void _ExitTree()
	{
		WaveManager.EndWave -= EndOfWave;
	}

	private void EndOfWave (int wave)
	{
		this.Visible = true;
		GetTree().Paused = true;
	}

	private void Continue()
	{
		this.Visible = false;
		GetTree().Paused = false;
	}
}
