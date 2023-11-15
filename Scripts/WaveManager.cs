using Godot;

public static class WaveManager
{
    private static readonly int EnemiesPerWave = 10;

    public static int CurrentWaveKills { get; private set; }
    private static int curretWave = 1;
    public static int CurrentWaveNum { get { return curretWave; } }

    public delegate void Wave(int wave);
    public static event Wave EndWave;

    public static void EnemyKilled()
    {
        CurrentWaveKills++;
        if (CurrentWaveKills >= EnemiesPerWave)
        {
            EndRound();
        }
    }

    private static void EndRound()
    {
        EndWave(CurrentWaveNum);
        GD.Print("--You finished Wave #" + curretWave + "--\n");

        CurrentWaveKills = 0;
        curretWave++;
    }
}
