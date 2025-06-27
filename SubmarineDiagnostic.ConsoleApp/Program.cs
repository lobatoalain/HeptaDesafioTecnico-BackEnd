using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SubmarineDiagnostic.ConsoleApp;
using SubmarineDiagnostic.Core.Interfaces;
using SubmarineDiagnostic.Core.Services;
using SubmarineDiagnostic.Infrastructure.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<IDiagnosticService, DiagnosticService>();
        services.AddTransient<DiagnosticApp>();
    })
    .Build();

var app = host.Services.GetRequiredService<DiagnosticApp>();
await app.RunAsync(args);

