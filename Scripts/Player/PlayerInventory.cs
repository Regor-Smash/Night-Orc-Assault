using Godot;

public static class PlayerInventory
{
    public static int Gold { get; private set; }

    public static void GetPaid(int amount)
    {
        if (amount <= 0)
        {
            GD.PrintErr("Payment must be for a positive amount.");
            return;
        }
        Gold += amount;
    }
}
