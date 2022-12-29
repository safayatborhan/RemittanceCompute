public class Remittance
{
    // Calculate the precise amount that needs to be sent and updates the reference variable "amount".
    public static Task Calculate(ref decimal amount, ref decimal moneyToSend, decimal incentive)
    {       
        var obtainedIncentive = moneyToSend * (incentive / 100);
        var leftOverAmount = moneyToSend - obtainedIncentive;
        var incentiveAmountForLeftOver = leftOverAmount * (incentive / 100);
        moneyToSend = obtainedIncentive - incentiveAmountForLeftOver;
        amount += leftOverAmount; // amount is the final amount that needs to be sent.

        // moneyToSend is decreasing as for each iteration we are subtracting the incentive amount. 
        if (Math.Round(moneyToSend) != 0)
        {
            Calculate(ref amount, ref moneyToSend, incentive);
        }

        return Task.CompletedTask;
    }
}