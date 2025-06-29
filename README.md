# MP CalcHub

**Nome em Inglês:** Multiple Platform Calculation Hub  
**Nome em Português:** Hub de Cálculos para Múltiplas Plataformas

## Integrantes do Grupo

- Gabriel Loureiro
- Gabriel Domingos
- Matheus Bellini
- Anderson Mello

## Descrição

Este é um projeto de pós-graduação em Arquitetura de Software, desenvolvido pelo Grupo 13 da faculdade. O MP CalcHub visa proporcionar uma estrutura para o desenvolvimento de cálculos de seguros, utilizando as melhores práticas de arquitetura e design de software.

## Tecnologias Utilizadas

- **.NET 8**
- **C# 12**
- **DDD (Domain-Driven Design)**
- **TDD (Test-Driven Development)**
- **BDD (Behavior-Driven Development)**

## Conteúdo do Projeto

O projeto abordará os seguintes tópicos:

** Fase 1
1. **Novidades do .NET 8 e C# 12**
2. **Desenvolvimento de API com .NET**
3. **Middlewares e Injeção de Dependência**
4. **Trabalhando com Logs**
5. **Serialização de Dados em JSON e MessagePack**
6. **Autenticação e Autorização**
7. **Documentação de API**
8. **Trabalhando com Cache**

## Fase 2
1. GitHub Actions
2. Azure Pipelines
3. Dockerfile
4. Prometheus
5. Grafana

## Estrutura do Projeto

O projeto inicial conterá uma estrutura básica para trabalhar com cálculos de seguros. Espera-se que, ao longo do desenvolvimento, a aplicação evolua para abranger diversas funcionalidades relacionadas ao cálculo e à gestão de seguros, mantendo a escalabilidade e a manutenibilidade como princípios fundamentais.

## Contribuição

Se você deseja contribuir para este projeto, sinta-se à vontade para abrir um problema (issue) ou enviar um pull request.

## Como rodar o projeto

** Instalações
Dotnet 8 SDK e 
Dotnet 8 Tools

** Instalador docker
https://www.docker.com/products/docker-desktop/

** Instalação do SQL no Docker --> PowerShell Administrator

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=@fiap2024" -p 1433:1433 --name SqlServerFiap -d mcr.microsoft.com/mssql/server:2022-latest

** Instalar o SQL Management Studio
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

dotnet ef migrations add "Adicionar o nome da Migration Aqui" --project Fiap.Hackatoon.Product.Consumer.Infrastructure --startup-project Fiap.Hackatoon.Product.Consumer.Api

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

