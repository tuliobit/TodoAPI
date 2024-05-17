# Todo API

A Todo API fornece uma interface simples para gerenciar uma lista de tarefas (to-dos). Suporta operações para criar, ler, atualizar e deletar itens de tarefas. A API é construída usando ASP.NET 8 e está hospedada no Azure. Está disponível no GitHub [aqui](https://github.com/tuliobit/TodoAPI).

A documentação da API é gerada automaticamente usando o Swagger e está em conformidade com a especificação OpenAPI.

## Começando

### Pré-requisitos
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download)
- Uma instância do SQL Server em execução.

### Instalação
0. Execute seu terminal de preferência no diretório em que deseja salvar o projeto.
   
1. Clone o repositório:
   ```git clone https://github.com/tuliobit/TodoAPI.git```
2. Navegue para o novo diretório:
   ```cd TodoAPI```
3. Restaure as dependências do projeto:
   ```dotnet restore```
4. Construa o projeto:
   ```dotnet build```
5. [Configure o SQL Server](#configurando-o-sql-server)    
6. Execute as migrações de banco do projeto:
   ```dotnet ef database update```
7. Execute o projeto:
   ```dotnet run```      

## Configurando o SQL Server
1. Instale o SQL Server:
   - [Download do SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
   - Siga as instruções de instalação fornecidas pela Microsoft - Salve a ConnectionString informada pelo instalador, se houver. Será útil em breve.

2. Crie um banco de dados:
   - Abra o SQL Server Management Studio (SSMS).
   - Conecte-se à sua instância do SQL Server.
   - Crie um novo banco de dados chamado `TodoDB` (ou outro nome de sua preferência):
     ```sql
     CREATE DATABASE TodoDB;
     ```

### Configurando o appsettings.json

1. Abra o arquivo `appsettings.json` no diretório raiz do projeto.
2. Substitua ```${DefaultConnectionString}``` pela ConnectionString do seu banco para conectar ao seu banco de dados SQL Server:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=TodoDB;User Id=your_username;Password=your_password;"
  },
  ...
}
```
Certifique-se de substituir your_server_name, your_username, e your_password pelos valores corretos da sua configuração do SQL Server.
   
