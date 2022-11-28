var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/calculated-amount/amount-to-send/{amount}/conversion-rate/{rate}/incentive-percentage/{incentive}/transaction-cost/{transactionCost}",
    (decimal amount, decimal rate, decimal incentive, decimal transactionCost) =>
{
    decimal amountToSend = 0;

    Remittance.Calculate(ref amountToSend, ref amount, incentive);

    var totalAmount = (amountToSend / rate) + transactionCost;

    return Math.Round(totalAmount, 2);
})
.WithName("GetCalculatedAmount");

app.Run();