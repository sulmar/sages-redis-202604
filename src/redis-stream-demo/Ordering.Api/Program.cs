using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse("localhost:6379");
    return ConnectionMultiplexer.Connect(configuration);
});

var app = builder.Build();

app.MapGet("/", () => "Hello Ordering.Api!");

app.MapPost("/api/orders", async (OrderRequest request, IConnectionMultiplexer redis) =>
{
    var db = redis.GetDatabase();

    // XADD orders * OrderId <orderId> CustomerId <customerId> Amount <amount>
    var messageId = await db.StreamAddAsync("orders",
    [
        new NameValueEntry("OrderId", request.OrderId),
        new NameValueEntry("CustomerId", request.CustomerId),
        new NameValueEntry("Amount", request.Amount.ToString())
    ]);

    return Results.Ok(new
    {
        Message = $"Order {request.OrderId} for customer {request.CustomerId} with amount {request.Amount} has been placed.",
        StreamId = messageId.ToString()
    });
});



app.Run();


record OrderRequest(string OrderId, string CustomerId, decimal Amount);