using System.Collections.Generic;
using WorkerService.Entities.Entities;

namespace WorkerService.Interfaces.Interfaces.Services;

public interface IExcelService
{
    List<Funcionario> LerExcel();
}
