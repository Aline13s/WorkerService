﻿using WorkerService.Entities.Entities;

namespace WorkerService.Interfaces.Interfaces;

public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>> GetAllAsync();
    Task<Funcionario> GetByIdAsync(int id);
    Task AddAsync(Funcionario funcionario);
    Task AddMultipleAsync(List<Funcionario> funcionarios);
    Task UpdateAsync(Funcionario funcionario);
    Task DeleteAsync(int id);
}
