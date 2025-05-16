# TaskPilot

TaskPilot é uma aplicação para gerenciamento de tarefas, desenvolvida utilizando .NET 9.0. O projeto é estruturado em uma arquitetura de camadas, com foco em escalabilidade, modularidade e boas práticas de desenvolvimento.

## Estrutura do Projeto

O projeto está organizado em várias camadas, cada uma com responsabilidades específicas:

- **TaskPilot.Api**: Camada de apresentação, responsável por expor endpoints RESTful para interação com a aplicação.
- **TaskPilot.Application**: Contém a lógica de negócios e os casos de uso da aplicação.
- **TaskPilot.Domain**: Define as entidades, interfaces e regras de negócio fundamentais.
- **TaskPilot.Infra.Data**: Implementa a persistência de dados, utilizando Entity Framework Core com SQLite.

## Tecnologias Utilizadas

- **.NET 9.0**: Framework principal para desenvolvimento da aplicação.
- **Entity Framework Core**: ORM para manipulação do banco de dados SQLite.
- **SQLite**: Banco de dados utilizado para persistência.
- **Swashbuckle.AspNetCore**: Para documentação e geração de Swagger/OpenAPI.
- **Microsoft.AspNetCore.OpenApi**: Para suporte a APIs RESTful.

## Endpoints Principais

Os endpoints estão definidos no controlador [`AppTasksController`](c:/Fontes/TaskPilot/TaskPilot.Api/controllers/AppTasksController.cs). Abaixo estão os principais endpoints disponíveis:

- **POST /api/AppTasks**: Cria uma nova tarefa.
- **GET /api/AppTasks**: Retorna todas as tarefas.
- **PUT /api/AppTasks/{id}**: Atualiza uma tarefa existente.
- **DELETE /api/AppTasks/{id}**: Remove uma tarefa.

## Configuração e Execução

### Pré-requisitos

- .NET SDK 9.0
- SQLite

### Passos para executar o projeto

1. Clone o repositório:
   ```bash
   git clone <url-do-repositorio>  
   cd TaskPilot

2. Restaure as dependências:
   ```bash
   dotnet restore
   
3. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update --project TaskPilot.Infra.Data

4. Inicie a aplicação:
   ```bash
   dotnet run --project TaskPilot.Api

5. Acesse a documentação Swagger em:
   ```bash
   http://localhost:<porta>/swagger
