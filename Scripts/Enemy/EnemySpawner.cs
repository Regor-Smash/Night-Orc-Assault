using Godot;

public partial class EnemySpawner : Node2D
{
	[Export]
	private PackedScene defaultEnemy;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(GetChildCount() > 0)
		{
			GD.Print(this.Name + " already has children and wont spawn enemies.");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(GetChildCount() == 0)
		{
			SpawnEnemy(defaultEnemy);
		}
	}

	public void SpawnEnemy(PackedScene enemyScene)
	{
		Node enemyNode = enemyScene.Instantiate();
		this.AddChild(enemyNode);
		GD.Print("SPAWNED AN ENEMY");
	}
}
