using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;
using WorkerService.Entities.Entities;
using WorkerService.Interfaces.Interfaces.Services;

namespace WorkerService.Services.Services;

public class ExcelService : IExcelService
{
    private readonly string _filePath = @"C:\service\dados_mock.xlsx";

    public List<Funcionario> LerExcel()
    {
        var funcionarios = new List<Funcionario>();

        if (!File.Exists(_filePath))
        {
            Console.WriteLine($"Arquivo não encontrado: {_filePath}");
            return funcionarios;
        }

        // Necessário para suportar caracteres especiais
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using var stream = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = ExcelReaderFactory.CreateReader(stream);
        var result = reader.AsDataSet();
        var table = result.Tables[0]; // Lendo a primeira planilha

        for (int i = 1; i < table.Rows.Count; i++) // Pulando o cabeçalho
        {
            var row = table.Rows[i];

            funcionarios.Add(new Funcionario
            {
                Nome = row[1].ToString()!,
                Cpf = row[2].ToString()!,
                Email = row[3].ToString()!,
                Telefone = row[4].ToString()!,
                Endereco = row[5].ToString()!,
                Cidade = row[6].ToString()!,
                Estado = row[7].ToString()!,
                DataNascimento = DateTime.Parse(row[8].ToString()!),
                Cargo = row[9].ToString()!,
                Salario = Convert.ToDecimal(row[10]),
                DataAdmissao = DateTime.Parse(row[11].ToString()!)
            });
        }

        return funcionarios;
    }
}
