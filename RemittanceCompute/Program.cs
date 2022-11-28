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

var totalAmount = (amount/conversionRate) + transactionCost;

Console.WriteLine($"Total amount: {Math.Round(totalAmount, 2)}");
