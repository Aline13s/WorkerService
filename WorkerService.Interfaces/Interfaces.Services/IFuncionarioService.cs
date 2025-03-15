using WorkerService.Entities.Entities;

namespace WorkerService.Interfaces.Interfaces.Services;

public interface IFuncionarioService
{
    Task<IEnumerable<Funcionario>> GetFuncionariosAsync();
    Task<Funcionario> GetFuncionarioByIdAsync(int id);
    Task AddFuncionarioAsync(Funcionario funcionario);
    Task AddFuncionariosAsync(List<Funcionario> funcionarios);
    Task UpdateFuncionarioAsync(Funcionario funcionario);
    Task DeleteFuncionarioAsync(int id);
}
