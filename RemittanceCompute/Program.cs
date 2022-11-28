Console.WriteLine("Money to send: ");
decimal.TryParse(Console.ReadLine(), out decimal moneyToSend);

Console.WriteLine("Conversion rate: ");
decimal.TryParse(Console.ReadLine(), out decimal conversionRate);

Console.WriteLine("Incentive percentage: ");
decimal.TryParse(Console.ReadLine(), out decimal incentive);

Console.WriteLine("Transaction cost: ");
decimal.TryParse(Console.ReadLine(), out decimal transactionCost);

decimal amount = 0;

Remittance.Calculate(ref amount, ref moneyToSend, incentive);

var totalAmount = amount + transactionCost;

Console.WriteLine($"Total amount: {totalAmount}");

public class Remittance
{
    public static decimal Calculate(ref decimal amount, ref decimal moneyToSend, decimal incentive)
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

        return moneyToSend;
    }
}