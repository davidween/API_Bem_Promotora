Criar pasta CRUD_DOTNET
    - dotnet new solution --name API_BEM_PROMOTORA

    - dotnet new webapi --output Application
    - dotnet new classlib --output Service
    - dotnet new classlib --output Domain
    - dotnet new classlib --output Infrastructure
    - dotnet new xunit --output Tests
    - dotnet new console --output MicroServices

    - dotnet sln add Application\
    - dotnet sln add Service\
    - dotnet sln add Domain\
    - dotnet sln add Infrastructure\
    - dotnet sln add ./Tests/Tests.csproj

    - dotnet sln list
    - git push
    - dotnet clean
    // Quando acusa algo errado, mas não existe.

    - Pasta Domain
        * Criar Pastas { Entities, Validators }
        * dotnet add package fluentvalidation

    - Pasta Infrastructure
        * Criar Pastas { Context, Interfaces, Repositories, Mappings, Migrations }
        * dotnet add package Microsoft.EntityFrameworkCore
        * dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        * dotnet add package Microsoft.EntityFrameworkCore.Design
        * dotnet add package Microsoft.EntityFrameworkCore.Tools
        * dotnet add package Dapper --version 2.0.90

    - Pasta Service
        * Criar Pastas { DataTransferObject, Services, Interfaces }
        * dotnet add package automapper
        * dotnet add package MassTransit --version 7.2.3-develop.226
        * dotnet add package MassTransit.RabbitMQ --version 7.2.3-develop.226

    - Pasta Application
        * Criar Pastas { ViewModels, Utilities, Token }
        * dotnet add package automapper
        * dotnet add package Microsoft.AspNet.WebApi.Client
        * dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
        * dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect
        * dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
        * dotnet add package MassTransit --version 7.2.3-develop.226
        * dotnet add package MassTransit.RabbitMQ --version 7.2.3-develop.226
        * dotnet add package MassTransit.AspNetCore --version 7.2.3-develop.226

    - Pasta MicroServices
        * dotnet add package MassTransit --version 7.2.3-develop.226
        * dotnet add package MassTransit.RabbitMQ --version 7.2.3-develop.226
        * dotnet add package Dapper --version 2.0.90
        * dotnet add package System.Data.SqlClient --version 4.8.2
    

    - dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
    // Infrastructure   ->    Domain
    // Infrastructure enxerga Domain
    - dotnet add Service/Service.csproj reference Domain/Domain.csproj
    - dotnet add Service/Service.csproj reference Infrastructure/Infrastructure.csproj
    - dotnet add Application/Application.csproj reference Infrastructure/Infrastructure.csproj  {Necessário para adição no escopo do Startup.cs}
    - dotnet add Application/Application.csproj reference Service/Service.csproj
    - dotnet add Application/Application.csproj reference Domain/Domain.csproj
    - dotnet add ./Tests/Tests.csproj reference ./Service/Service.csproj
    - dotnet add ./Tests/Tests.csproj reference ./MicroServices/MicroServices.csproj