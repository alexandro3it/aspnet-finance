# e-Finance
## Controle Financeiro de Lançamentos de Créditos/Débitos e Saldo Diário

(https://github.com/alexandro3it/aspnet-finance)

Desenvolvido principalmente na tecnologia ASP.Net Core 6.

## Funcionalidades

- Lançamento de Créditos diários
    - Pode ser feita a listagem inicial com todos os Lançamentos de créditos cadastrados;
    - Pode set feita a Inclusão de novos lançamentos através da opção "Lançar um novo crédito";
    - Pode set feita a Alteração de lançamentos cadastrados através da opção "Alterar";
    - Pode set feita a Exclusão de lançamentos cadastrados através da opção "Excluir";
- Lançamento de Débitos diários
    - Pode ser feita a listagem inicial com todos os Lançamentos de débitos cadastrados;
    - Pode set feita a Inclusão de novos lançamentos através da opção "Lançar um novo débito";
    - Pode set feita a Alteração de lançamentos cadastrados através da opção "Alterar";
    - Pode set feita a Exclusão de lançamentos cadastrados através da opção "Excluir";
- Relatório com Saldo diário por período
    - Pode ser feita a listagem inicial com o período selecionado com todos os Lançamentos de Créditos/Débitos lançados, assim resultando em uma planilha com a sumarização dos mesmo por dia, com Saldo Inicial, Total de entrada(s), Total de saída(s) e Saldo final ;


## Tecnologias

Algumas das tecnologias utilizadas:

- [ASP.Net Core 6] - Desenvolvimento HTML com .Net
- [Entity Framework Core 6] - ORM .Net para persistência em Database
- [Dapper] - Micro-ORM para persistência em Database
- [Mapper] - Biblioteca para separação de responsabilidade entre classes de Domínio, Persistência e Modelo
- [Mediator] - Biblioteca que implementa o Padrão Mediator para interações de diferentes tipos de objetos através de chamadas síncronas e assíncronas.
- [MVC] - (Model-View-Controller) - O princípio básico é a divisão da aplicação em três camadas: a camada de interação do usuário (View), a camada de manipulação dos dados (Model) e a camada de controle (Controller).
- [DDD] - (Domain-Driven Design) - Orienta o desenvolvimento com foco em domínio.
--Entity
--AggregateRoot
--Repository
--Services
- Banco de dados SQL Server Express
- [MSTest] - (Microsoft Test Framework) - Mais conhecido como MSTest, nasceu como uma ferramenta de testes unitários para aplicações .NET integrada com o Visual Studio.

## Construção/Execução

Aplicação Web

Utilizando linha comando como powershell(Terminal):

[dir] = onde foi feita o clone ou download da aplicação + \finance

```sh
cd [dir]
dotnet ef database update
dotnet build
dotnet run

Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7258
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5146
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ...\finance\
```

Abrir o Browser no endereço  listado acima, no caso https://localhost:7258

Utilizando Visual Studio

[dir] = onde foi feita o clone ou download da aplicação + \finance

```sh
cd [dir]
Abrir o projeto ASPFinance.sln
Definir o projeto ASPFinance como projeto principal 
F5 para Compilar/Executar ou menu Debug/Start Debugging
```

Execução de Testes

Utilizando linha comando como powershell(Terminal):

[dir] = onde foi feita o clone ou download da aplicação + \finance.Tests

```sh
cd [dir]
dotnet build
dotnet test

Utilizando Visual Studio

[dir] = onde foi feita o clone ou download da aplicação + \finance.Tests

```sh
cd [dir]
Abrir o projeto ASPFinance.sln
Definir o projeto ASPFinance como projeto principal
Abrir a Janela - Test Explorer, clicar no botão Run ou Run All Tests In View
```

## Pasta de documentos.

- /docs
-- /c4model - Desenho da solução do nível mais macro ao nível nivel mais detalhado para frontend e backend.
-- /mindmap - Mapa mental da aplicação.
-- /MER - Modelagem Entidade Relacionamento do banco de dados.


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [alexandro-ribeiro]: <https://github.com/alexandro3it>
