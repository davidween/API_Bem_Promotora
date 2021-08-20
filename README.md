Criar pasta CRUD_DOTNET
    - dotnet new solution --name API_BEM_PROMOTORA

    - dotnet new webapi --output Application
    - dotnet new classlib --output Service
    - dotnet new classlib --output Domain
    - dotnet new classlib --output Infrastructure

    - dotnet sln add Application\
    - dotnet sln add Service\
    - dotnet sln add Domain\
    - dotnet sln add Infrastructure\

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

    - Pasta Service
        * Criar Pastas { DataTransferObject, Services, Interfaces }
        * dotnet add package automapper

    - Pasta Application
        * Criar Pastas { ViewModels, Utilities }
        * dotnet add package automapper
        * dotnet add package Microsoft.AspNet.WebApi.Client
    

    - dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
    // Infrastructure   ->    Domain
    // Infrastructure enxerga Domain
    - dotnet add Service/Service.csproj reference Domain/Domain.csproj
    - dotnet add Service/Service.csproj reference Infrastructure/Infrastructure.csproj
    - dotnet add Application/Application.csproj reference Infrastructure/Infrastructure.csproj  {Tentar Retirar}
    - dotnet add Application/Application.csproj reference Service/Service.csproj
    - dotnet add Application/Application.csproj reference Domain/Domain.csproj
    







    
    - Criar pasta Entities
        * dotnet new classlib

    - dotnet sln add Entities\
    - dotnet sln list
    - dotnet build

    - Criar pasta Application
        * dotnet new mvc
        * dotnet add package Newtonsoft.Json --version 13.0.1

    - dotnet sln add Application\
    - dotnet sln list
    - dotnet build

    - cd Application
        * dotnet run
        * Ctrl C
        * cd ..
    
    - Criar pasta ORM
        * dotnet new classlib
        * dotnet add package Microsoft.Extensions.Configuration
        * dotnet add package System.Data.SqlClient
        * dotnet add package Dapper

    - dotnet sln add ORM\
    - dotnet sln list
    - dotnet build

    - Entrar na pasta ORM:
        * Criar pasta Interfaces

    - dotnet add ORM/ORM.csproj reference Entities/Entities.csproj
    // Irei utilizar a classe TODO do projeto Entities no projeto ORM

    - dotnet add Application/Application.csproj reference Entities/Entities.csproj
    - dotnet add Application/Application.csproj reference ORM/ORM.csproj
    // O projeto Application pode se comunicar com os projetos Entities e ORM

    - cd Application
        * dotnet add package bootstrap --version 5.0.2
        * cd ..
    - dotnet build
    




Caso OmniSharp não funcione:
    - Na paleta de comandos:
        * OmniSharp Restart
        * OmniSharp Select Solution




-----------System.ComponentModel.DataAnnotations

Key — Define o atributo como a chave primária.

Timestamp — Seja um timestamp para aquele atributo.

Required — Define o atributo como obrigatório.

MinLength e MaxLength — Respectivamente define o número mínimo e máximo de caracteres.

-----------System.ComponentModel.DataAnnotations.Schema

Table — Nomeia uma tabela para determinada classe.

Column — Nomeia uma coluna para determinado atributo.

ForeignKey — Determina uma relação do tipo chave estrangeira em um atributo.

NotMapped — Atributo "dummy", não possui relação com a base de dados, não mapeado.



A camada de dados é um proxy que fica entre a origem das requests (neste caso, aplicação MVC) e sua camada de entidades. 
Nesta camada, recebemos a request, realizamos a transação com a base de dados, 
é feito um trabalho de serialização e deserialização pelo ORM com a camada de entidades e é retornado um objeto para a camada de aplicação.

Utilizamos um pattern muito famoso no desenvolvimento web: O repository pattern.

Sua implementação trás vantagens ao seu sistema, tais como:

Padroniza as transações por cada entidade existente.

Permite que seja possível você trocar o seu ORM futuramente.

Permite que seu código seja mais limpo.




- Application faz request para a camada Dados

- Dados(ORM) faz uma rquest para a camada Entities

- Serialização e deserialização

- Dados(ORM) retorna para camada Application


/home/m-david/snap/dbeaver-ce/138/.local/share/DBeaverData/workspace6/General/Scripts/Script-CRUDdotnet.sql



O objeto ModelState
Nesta última aula, utilizamos do objeto ModelState da classe Controller para verificar se o objeto populado (no caso um ToDo) 
bate de acordo com as annotations utilizadas no projeto Entitites.

Caso o objeto "obj" que foi recebido por parâmetro deste método não estiver OK de acordo as validações feitas com as Data Annotations, 
o atributo IsValid do objeto ModelState retorna false. Caso esteja OK, ele retorna True e permite continuarmos com a inclusão na base de dados.

O intuito disso é evitarmos exceptions durante a transação com a base de dados, inclusive, através do objeto 
ModelState podemos obter quais os erros e em qual atributo está o problema.
