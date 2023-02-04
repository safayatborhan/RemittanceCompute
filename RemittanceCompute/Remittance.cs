public class Remittance
{
    // Calculate the precise amount that needs to be sent and updates the reference variable "amount".
    public static Task Calculate(ref decimal amount, ref decimal moneyToSend, decimal incentive)
    {
        amount = Math.Ceiling(moneyToSend / (1 + incentive / 100));
        return Task.CompletedTask;
    }
}