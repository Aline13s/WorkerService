using WorkerService.Entities.Entities;
using WorkerService.Interfaces.Interfaces;
using WorkerService.Interfaces.Interfaces.Services;

namespace WorkerService.Services.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Funcionario>> GetFuncionariosAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Funcionario> GetFuncionarioByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddFuncionarioAsync(Funcionario funcionario)
    {
        await _repository.AddAsync(funcionario);
    }

    public async Task AddFuncionariosAsync(List<Funcionario> funcionarios)
    {
        foreach (var funcionario in funcionarios)
        {
            await _repository.AddAsync(funcionario);
        }
    }

    public async Task UpdateFuncionarioAsync(Funcionario funcionario)
    {
        await _repository.UpdateAsync(funcionario);
    }

    public async Task DeleteFuncionarioAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
