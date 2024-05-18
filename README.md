# TES-CSharp

TES-CSharp é uma API para gerenciamento de uma biblioteca, desenvolvida em C#. A API permite gerenciar livros, usuários e empréstimos. Este projeto foi desenvolvido por:

- Daniel Tavares: [GitHub](https://github.com/danilomf96)
- Danilo Marques Ferreira: [GitHub](https://github.com/danilomf96)
- Victor Matheus Lucas Martins: [GitHub](https://github.com/Vimlm)

## Entidades/Modelos

### Livro
Representa um livro na biblioteca. Contém as seguintes propriedades:
- `Id` (int): Identificador único do livro.
- `Titulo` (string): Título do livro.
- `Autor` (string): Autor do livro.
- `AnoPublicacao` (int): Ano de publicação do livro.

### Usuário
Representa um usuário da biblioteca. Contém as seguintes propriedades:
- `Id` (int): Identificador único do usuário.
- `Nome` (string): Nome do usuário.
- `Email` (string): Email do usuário.
- `Senha` (string): Senha do usuário.

### Empréstimo
Representa um empréstimo de um livro para um usuário. Contém as seguintes propriedades:
- `Id` (int): Identificador único do empréstimo.
- `LivroId` (int): Identificador do livro emprestado.
- `UsuarioId` (int): Identificador do usuário que pegou o livro emprestado.
- `DataEmprestimo` (DateTime): Data em que o livro foi emprestado.
- `DataDevolucao` (DateTime): Data prevista para devolução do livro.

## Rotas

### Livros

- `POST /biblioteca/livro/cadastrar`
  - Descrição: Cadastra um novo livro na biblioteca.
  - Corpo da requisição: Objeto JSON com as propriedades `Titulo`, `Autor` e `AnoPublicacao`.

- `GET /biblioteca/livro/listar`
  - Descrição: Lista todos os livros cadastrados na biblioteca.

- `GET /biblioteca/livro/buscar/{titulo}`
  - Descrição: Busca livros pelo título.
  - Parâmetros: `titulo` - Título do livro a ser buscado.

### Usuário

- `POST /biblioteca/usuario/cadastrar`
  - Descrição: Cadastra um novo usuário na biblioteca.
  - Corpo da requisição: Objeto JSON com as propriedades `Nome`, `Email` e `Senha`.

- `GET /biblioteca/usuario/listar`
  - Descrição: Lista todos os usuários cadastrados na biblioteca.

- `GET /biblioteca/usuario/buscar/{email}`
  - Descrição: Busca um usuário pelo email.
  - Parâmetros: `email` - Email do usuário a ser buscado.

- `DELETE /biblioteca/usuario/remover/{email}`
  - Descrição: Remove um usuário pelo email.
  - Parâmetros: `email` - Email do usuário a ser removido.

- `PUT /biblioteca/usuario/alterar/{email}`
  - Descrição: Altera as informações de um usuário.
  - Parâmetros: `email` - Email do usuário a ser alterado.
  - Corpo da requisição: Objeto JSON com as propriedades que deseja alterar.

### Empréstimo

- `POST /biblioteca/emprestimo/emprestar/{email}`
  - Descrição: Registra um novo empréstimo para um usuário.
  - Parâmetros: `email` - Email do usuário que está emprestando o livro.
  - Corpo da requisição: Objeto JSON com a propriedade `LivroId`.

- `POST /biblioteca/emprestimo/devolver/{id}`
  - Descrição: Registra a devolução de um livro.
  - Parâmetros: `id` - Identificador do empréstimo a ser devolvido.

- `PUT /biblioteca/emprestimo/renovar/{id}`
  - Descrição: Renova o prazo de devolução de um empréstimo.
  - Parâmetros: `id` - Identificador do empréstimo a ser renovado.

- `GET /biblioteca/emprestimo/listar`
  - Descrição: Lista todos os empréstimos registrados.

- `GET /biblioteca/emprestimo/buscar/{id}`
  - Descrição: Busca um empréstimo pelo identificador.
  - Parâmetros: `id` - Identificador do empréstimo a ser buscado.

## Como Executar

1. Clone o repositório:
    ```bash
    git clone https://github.com/Nebula-Forge/TES-CSharp.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd BibliotecaApi
    ```

3. Restaure as dependências:
    ```bash
    dotnet restore
    ```

4. Adicione uma nova migração (substitua `NomeDaSuaMigracao` por um nome descritivo para a migração):
    ```bash
    dotnet ef migrations add NomeDaSuaMigracao
    ```

5. Atualize o banco de dados para aplicar a migração:
    ```bash
    dotnet ef database update
    ```

6. Execute a aplicação:
    ```bash
    dotnet run
    ```

A API estará disponível em `http://localhost:{sua porta}`. (**Substitua `{sua porta}` pela porta fornecida no terminal quando o comando `dotnet run` for executado.**)

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
