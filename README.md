# Sistema de Diagnóstico de Submarino

## 📝 Descrição
Sistema para análise de consumo de energia de submarinos baseado em relatórios de diagnóstico em formato binário. Calcula as taxas Gama e Épsilon para determinar o consumo energético.

## 🛠️ Tecnologias
- .NET 9.0
- C# 12.0
- XUnit (para testes)
- Moq (para testes unitários)

## ⚙️ Configuração do Projeto

### Estrutura de Arquivos
SubmarineDiagnostic/
├── data/                         
│   └── diagnostic_report.txt       ← Arquivo de entrada com números binários
│
├── SubmarineDiagnostic.Core/       ← Regras de negócio, modelos e interfaces
├── SubmarineDiagnostic.Infrastructure/ ← Implementações de serviços e lógica concreta
├── SubmarineDiagnostic.ConsoleApp/ ← Aplicação de console para execução do cálculo
└── SubmarineDiagnostic.Tests/      ← Testes unitários


## 🚀 Como Executar

### Via Linha de Comando

# Navegue até a pasta do projeto
cd SubmarineDiagnostic.ConsoleApp

# Opção 1: Execute com o caminho do arquivo
dotnet run data\diagnostic_report.txt

# Opção 2: Modo interativo (será solicitado o caminho)
dotnet run
Quando executado no modo interativo, o programa solicitará:
Por favor, informe o caminho do arquivo de relatório:
> _

Informe o caminho relativo (ex: data\diagnostic_report.txt) ou absoluto (ex: C:\caminho\completo\diagnostic_report.txt)

# No Visual Studio
Pressione F5 para iniciar

Quando solicitado, informe o caminho do arquivo

# 🔍 Padrões de Projeto Utilizados
Injeção de Dependência: Para desacoplar componentes

Repository Pattern: Para acesso a dados

Strategy Pattern: Para diferentes algoritmos de análise

# ✅ Testes
Execute os testes com:
dotnet test

## Cobertura de testes:

Testes unitários para lógica principal

Testes de integração para repositórios

Testes de comportamento para o serviço principal

# 📊 Exemplo de Saída
=== Relatório de Diagnóstico do Submarino ===
Taxa Gama: 10110 (decimal: 22)
Taxa Épsilon: 01001 (decimal: 9)
Consumo de Energia: 198
