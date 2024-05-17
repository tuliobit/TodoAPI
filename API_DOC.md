# Documentação da API - Todo API

A API Todo oferece endpoints para gerenciar uma lista de to-dos. Ela permite operações para criar, ler, atualizar e deletar itens de tarefas.

## Endpoints

### 1. Obter Todos os To-dos

- **URL**: `/todo`
- **Método**: `GET`
- **Descrição**: Recupera uma lista de to-dos baseado nos filtros informados.
- **Parâmetros de Consulta**:
  - `title` (opcional): Filtra itens cujo título contenha o texto informado.
  - `DeadlineFrom` (opcional): Filtra itens cujo prazo é, no mínimo, o informado.
  - `DeadlineUntil` (opcional): Filtra itens cujo prazo é, no máximo, o informado.
  - `IsComplete` (opcional): Filtra itens apenas finalizados ou não-finalizados.
  - `OrderBy` (opcional): Ordena os resultados da busca pela propriedade cujo nome foi informado.
  - `SortDescending` (opcional, apenas quando OrderBy informado): Define se a ordenação deve ser ascendente (`falso`) ou descendente (`true`)
- **Resposta**:
  - **Status 200 OK**: Sucesso. Retorna uma lista JSON de todos os to-dos.
  - **Status 500 Internal Server Error**: Ocorreu um erro no servidor.

### 2. Obter Todo por ID

- **URL**: `/todo/{id}`
- **Método**: `GET`
- **Descrição**: Recupera um to-do específico pelo ID.
- **Parâmetros**:
  - `id` (obrigatório): O ID do item de todo.
- **Resposta**:
  - **Status 200 OK**: Sucesso. Retorna JSON do to-do correspondente ao ID.
  - **Status 404 Not Found**: O to-do com o ID especificado não foi encontrado.
  - **Status 500 Internal Server Error**: Ocorreu um erro no servidor.

### 3. Criar um Novo To-do

- **URL**: `/todo`
- **Método**: `POST`
- **Descrição**: Cria um novo item de to-do.
- **Corpo da Requisição**:
  - `title` (obrigatório): O título do to-do. Deve ter entre 3 e 50 caracteres.
  - `deadline` (obrigatório): O prazo do to-do. Deve ser uma data futura.
- **Resposta**:
  - **Status 201 Created**: Sucesso. Retorna JSON do to-do criado.
  - **Status 400 Bad Request**: Requisição inválida. O corpo da requisição está ausente ou mal formatado. Retorna mensagem respectiva ao erro no modelo.
  - **Status 500 Internal Server Error**: Ocorreu um erro no servidor.

### 4. Atualizar um To-do

- **URL**: `/todo/{id}`
- **Método**: `PUT`
- **Descrição**: Atualiza um item to-do existente.
- **Parâmetros**:
  - `id` (obrigatório): O ID do item to-do.
- **Corpo da Requisição**:
  - `title` (obrigatório): O novo título do to-do. Deve ter entre 3 e 50 caracteres.
  - `deadline` (obrigatório): O novo prazo do to-do. Deve ser futuro ou inalterado.
- **Resposta**:
  - **Status 200 OK**: Sucesso. Retorna JSON do to-do atualizado.
  - **Status 400 Bad Request**: Requisição inválida. O corpo da requisição está ausente ou mal formatado. Retorna mensagem respectiva ao erro no modelo.
  - **Status 404 Not Found**: O to-do com o ID especificado não foi encontrado.
  - **Status 500 Internal Server Error**: Ocorreu um erro no servidor.

### 5. Deletar um To-do

- **URL**: `/todo/{id}`
- **Método**: `DELETE`
- **Descrição**: Deleta um item de to-do específico.
- **Parâmetros**:
  - `id` (obrigatório): O ID do item de to-do.
- **Resposta**:
  - **Status 204 No Content**: Sucesso. O to-do foi deletado com sucesso.
  - **Status 404 Not Found**: O to-do com o ID especificado não foi encontrado.
  - **Status 500 Internal Server Error**: Ocorreu um erro no servidor.

## Tratamento de Erros
A API retorna códigos de status HTTP padrão para indicar o sucesso ou falha de uma requisição. Em caso de erros, uma mensagem de erro descritiva também pode ser retornada no corpo da resposta.

- **200 OK**: A requisição foi bem-sucedida.
- **201 Created**: Um novo recurso foi criado com sucesso.
- **204 No Content**: A requisição foi bem-sucedida, mas não há conteúdo para retornar.
- **400 Bad Request**: A requisição não pôde ser entendida ou estava faltando parâmetros obrigatórios.
- **404 Not Found**: O recurso solicitado não pôde ser encontrado.
- **500 Internal Server Error**: Ocorreu um erro no servidor.
