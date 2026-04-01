using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Payment.Api;

public class PaymentWorker(ILogger<PaymentWorker> logger, IConnectionMultiplexer redis) : BackgroundService
{
    private const string StreamKey = "orders";
    private const string ConsumerGroupName = "payment-workers";


    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        var db = redis.GetDatabase();

        try
        {
            // XGROUP CREATE orders payment-workers 0 MKSTREAM
            await db.StreamCreateConsumerGroupAsync(StreamKey, ConsumerGroupName, "0", createStream: true);
        }
        catch { }

        await base.StartAsync(cancellationToken);

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var db = redis.GetDatabase();

        while (!stoppingToken.IsCancellationRequested)
        {
            // XREADGROUP GROUP payment-workers <consumerName> COUNT 1 STREAMS orders >
            var result = await db.StreamReadGroupAsync(StreamKey, ConsumerGroupName, Environment.MachineName, position: ">", count: 1);

            if (result.Length == 0)
            {
                await Task.Delay(1000, stoppingToken);
                continue;
            }

            foreach (var message in result)
            {
                var orderId = message["OrderId"];
                var customerId = message["CustomerId"];
                var amount = message["Amount"];

                logger.LogInformation("Processing payment for Order {orderId}, amount: {amount}", orderId, amount);

                // Symulate payment processing
                await Task.Delay(2000, stoppingToken);

                // XACK orders payment-workers <messageId>
                await db.StreamAcknowledgeAsync(StreamKey, ConsumerGroupName, message.Id);

                logger.LogInformation("Payment processed for Order {orderId}", orderId);
            }


        }
    }
}
