using Godot;

public partial class EnemyAttack : Area2D
{
    [ExportCategory("Refs")]
    [Export]
    private AnimationPlayer anim;
    
	// Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        this.BodyEntered += Attack; // detects PhysicsBody2D and TileMaps
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void Attack(Node2D n)
    {
        if(n == PlayerCharacter.Instance)
        {
            GD.Print("Fuck off");
        }
        anim.Play(name: "Attack");
    }
}
