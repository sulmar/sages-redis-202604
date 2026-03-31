using CsvHelper;
using CsvHelper.Configuration;
using icd10_api.Configurations;
using icd10_api.Models;
using StackExchange.Redis;

namespace icd10_api;


//  dotnet add package CsvHelper
public class CD10HostedService(IConnectionMultiplexer redis) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";",
        };

        using var reader = new StreamReader("ICD10en.csv");
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap<ClassificationMap>();

        var db = redis.GetDatabase();

        await db.PingAsync();

        var records = csv.GetRecordsAsync<ClassificationRecord>();

        // SADD        
        await foreach (var record in records)
        { 
            await db.SetAddAsync("icd10", $"{record.CategoryCode}|{record.Category}");            
        }                    
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}