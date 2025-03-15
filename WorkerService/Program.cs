using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WorkerService;
using WorkerService.Ioc;
using System.IO;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Define o diretório base do projeto
        config.SetBasePath(Directory.GetCurrentDirectory());

        // Carrega configurações do appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // Permite sobrescrever configurações via variáveis de ambiente
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        // Adiciona as configurações de IoC do WorkerService
        services.AddWorkerServices(hostContext.Configuration);

        // Adiciona o Worker como serviço em background
        services.AddHostedService<Worker>();
    })
    .Build();

await builder.RunAsync();
