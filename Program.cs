using BenchmarkDotNet.Running;
using Serilog;
using Serilog.Events;
using TheOmenDen.Shared.Benchmarks.Benchmarks;
using TheOmenDen.Shared.Extensions;

var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .Enrich.WithProcessId()
    .Enrich.WithProcessName()
    .Enrich.WithMemoryUsage()
    .WriteTo.Async(a =>
    {
        a.File("./logs/log-txt", rollingInterval: RollingInterval.Day);
        a.Console();
    })
    .CreateLogger();

try
{
    //var testEnumeration = Enumerable.Range(1, 10).ToArray();

    //var randomElement = testEnumeration.GetRandomElementFromArray();
    //var randomElements = testEnumeration.GetRandomElementsFromArray(5);

    //Console.WriteLine($"randomElement {randomElement}");

    //var elementPrint = string.Join(", ", randomElements);
    //Console.WriteLine($"random elements: [{elementPrint}]");
    _ = BenchmarkRunner.Run<ShufflingBenchmarks>();
}
catch (Exception ex)
{
    Log.Fatal("An error occurred before {AppName} could launch: {@Ex}", "Benchmarks", ex);
}
finally
{
    Log.CloseAndFlush();
}