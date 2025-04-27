# LAPR5 – ASP.NET Core Module

This repository contains the **ASP.NET Core 5.0** backend module for the **LAPR5** (Laboratório de Arquitetura e Projeto de Software 5) project, developed in 2022 as part of the Software Engineering master's curriculum at ISEP (Instituto Superior de Engenharia do Porto). It demonstrates the application of **Domain-Driven Design (DDD)**, **Onion Architecture**, and **Entity Framework Core** in a RESTful API template.

## 📋 Table of Contents

- [🚀 Overview](#-overview)  
- [🛠️ Technologies & Patterns](#️-technologies--patterns)  
- [📂 Repository Structure](#-repository-structure)  
- [🚀 Getting Started](#-getting-started)  
  - [Prerequisites](#prerequisites)  
  - [Build & Run](#build--run)  
  - [Database Migrations](#database-migrations)  
  - [Running Tests](#running-tests)  
- [🔧 CI/CD Pipelines](#-cicd-pipelines)  
- [📄 License & Disclaimer](#-license--disclaimer)  

## 🚀 Overview

The `management-dddnetcore` project is a template/example **ASP.NET Core 5.0 Web API** showcasing:

- **Onion Architecture** (clean separation of concerns)  
- **Domain-Driven Design (DDD)** with three aggregate roots:  
  - `Category`  
  - `Product`  
  - `Family`  
- **Entity Framework Core** for data persistence  
- Clear separation between:  
  1. **API** (Controllers / UserInterface)  
  2. **Domain** (Entities, Value Objects, Domain Services, DTOs)  
  3. **Infrastructure** (EF Core Repositories, Migrations)  
- Basic business rules and validation implemented at the domain layer  

A second project, **testProject**, provides unit and integration tests to validate domain logic and API behavior.

## 🛠️ Technologies & Patterns

- **C# • .NET 5.0**  
- **ASP.NET Core Web API**  
- **Entity Framework Core** (+ Code-First Migrations)  
- **Onion Architecture** (Ports & Adapters)  
- **Domain-Driven Design (DDD)**  
- **CQRS-style** separation of Commands & Queries (conceptual)  
- **xUnit** for testing  
- YAML pipelines for **Azure DevOps** & **Bitbucket Pipelines**  

## 📂 Repository Structure

```
/
├── management-dddnetcore/      ← Main ASP.NET Core 5.0 solution
│   ├── Controllers/            ← API controllers (REST endpoints)
│   ├── Domain/                 ← Aggregates, Entities, Value Objects, Services
│   ├── Infrastructure/         ← EF Core DbContext, Repositories, Migrations
│   ├── UserInterface/          ← Request/Response models, UI integration
│   ├── Migrations/             ← EF Core code-first migrations
│   ├── Program.cs              ← ASP.NET Core host setup
│   ├── Startup.cs              ← Middleware, DI, and service configuration
│   └── DDDNetCore.csproj       ← Project file
│
├── testProject/                ← Test suite for domain & API
│   ├── Tests/                  ← xUnit test classes
│   ├── Usings.cs               ← Global using directives
│   └── testProject.csproj      ← Project file
│
├── solutionFolder.sln          ← Visual Studio solution  
├── azure-pipelines.yml         ← Azure DevOps CI pipeline  
├── bitbucket-pipelines.yml     ← Bitbucket CI pipeline  
└── .gitignore
```

## 🚀 Getting Started

### Prerequisites

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) or later  
- [SQL Server](https://www.microsoft.com/sql-server) (Express or Developer)  
- (Optional) [Docker & Docker Compose](https://www.docker.com/) for containerized workflows  
- An IDE such as Visual Studio 2019+ or Visual Studio Code  

### Build & Run

1. **Clone the repository**  
   ```bash
   git clone https://github.com/GuilhermeCunha79/LAPR5.git
   cd LAPR5
   ```

2. **Restore & build**  
   ```bash
   dotnet restore
   dotnet build
   ```

3. **Run the API**  
   ```bash
   cd management-dddnetcore
   dotnet run
   ```
  
4. **Explore the API**  
   Navigate to https://localhost:5001/swagger to view the auto-generated Swagger UI.

### Database Migrations

```bash
# Apply EF Core database migrations
cd management-dddnetcore
dotnet ef database update
```

### Running Tests

```bash
# Run all tests
cd testProject
dotnet test
```

## 🔧 CI/CD Pipelines

This project includes configuration for two CI/CD pipelines:

- **Azure DevOps**: Defined in `azure-pipelines.yml` to build, test, and publish artifacts
- **Bitbucket Pipelines**: Defined in `bitbucket-pipelines.yml` for a similar CI workflow

## 👥 Contributors

This project was developed by ISEP students from Group 70 (2022):
- Guilherme Cunha
- Beatriz Cardoso
- Hugo Carvalho
- Érica Lopes

---
