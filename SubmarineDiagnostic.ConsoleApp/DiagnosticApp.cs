using SubmarineDiagnostic.Core.Interfaces;
using System;

namespace SubmarineDiagnostic.ConsoleApp;

public class DiagnosticApp
{
    private readonly IDiagnosticService _diagnosticService;

    public DiagnosticApp(IDiagnosticService diagnosticService)
    {
        _diagnosticService = diagnosticService;
    }

    public async Task RunAsync(string[] args)
    {
        try
        {
            string filePath;

            if (args.Length == 0)
            {
                Console.WriteLine("Por favor, informe o caminho do arquivo de relatório:");
                Console.Write("> ");
                filePath = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("Nenhum caminho foi fornecido. O programa será encerrado.");
                    return;
                }
            }
            else
            {
                filePath = args[0];
            }

            var result = await _diagnosticService.CalculatePowerConsumptionFromFileAsync(filePath);

            Console.WriteLine("\n=== Relatório de Diagnóstico do Submarino ===");
            Console.WriteLine($"Taxa Gama: {result.GammaRate.Value} (decimal: {result.GammaRate.ToDecimal()})");
            Console.WriteLine($"Taxa Épsilon: {result.EpsilonRate.Value} (decimal: {result.EpsilonRate.ToDecimal()})");
            Console.WriteLine($"Consumo de Energia: {result.Consumption}");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nErro: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}