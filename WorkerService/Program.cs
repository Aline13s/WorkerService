using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WorkerService;
using WorkerService.Ioc;
using System.IO;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Define o diret�rio base do projeto
        config.SetBasePath(Directory.GetCurrentDirectory());

        // Carrega configura��es do appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // Permite sobrescrever configura��es via vari�veis de ambiente
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        // Adiciona as configura��es de IoC do WorkerService
        services.AddWorkerServices(hostContext.Configuration);

        // Adiciona o Worker como servi�o em background
        services.AddHostedService<Worker>();
    })
    .Build();

await builder.RunAsync();
