using Microsoft.Extensions.DependencyInjection;
using WorkerService.Repositories.Repositories;
using WorkerService.Interfaces.Interfaces;
using WorkerService.Interfaces.Interfaces.Services;
using WorkerService.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkerService.Data.Context;

namespace WorkerService.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkerServices(this IServiceCollection services, IConfiguration configuration)
    {
        // REGISTRANDO O DB CONTEXT
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Adiciona os repositórios
        services.AddSingleton<IFuncionarioRepository, FuncionarioRepository>();

        // Adiciona os serviços
        services.AddSingleton<IFuncionarioService, FuncionarioService>();
        services.AddSingleton<IExcelService, ExcelService>();

        return services;
    }
}
