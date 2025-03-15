using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkerService.Interfaces.Interfaces.Services;
using WorkerService.Services.Services;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IFuncionarioService _funcionarioService;
    private readonly IExcelService _excelService;

    public Worker(ILogger<Worker> logger, IFuncionarioService funcionarioService, IExcelService excelService )
    {
        _logger = logger;
        _funcionarioService = funcionarioService;
        _excelService = excelService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Iniciando leitura do Excel...");

        var funcionarios = _excelService.LerExcel();

        if (funcionarios.Count == 0)
        {
            _logger.LogWarning("Nenhum funcionário encontrado no Excel.");
        }
        else
        {
            await _funcionarioService.AddFuncionariosAsync(funcionarios);
            _logger.LogInformation("Funcionários importados para o banco de dados com sucesso.");
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker rodando às: {time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
