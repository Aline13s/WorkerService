using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WorkerService;
using WorkerService.Ioc;
using System.IO;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory());

        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddWorkerServices(hostContext.Configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await builder.RunAsync();
