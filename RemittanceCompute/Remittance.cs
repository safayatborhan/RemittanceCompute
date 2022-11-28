






public class Remittance
{
    public static Task Calculate(ref decimal amount, ref decimal moneyToSend, decimal incentive)
    {       
        var obtainedIncentive = moneyToSend * (incentive / 100);
        var draftAmount = moneyToSend - obtainedIncentive;
        var incentiveAmountForDraft = draftAmount * (incentive / 100);
        moneyToSend = obtainedIncentive - incentiveAmountForDraft;
        amount += draftAmount;

        if (Math.Round(moneyToSend) != 0)
        {
            Calculate(ref amount, ref moneyToSend, incentive);
        }

        return Task.CompletedTask;
    }
}